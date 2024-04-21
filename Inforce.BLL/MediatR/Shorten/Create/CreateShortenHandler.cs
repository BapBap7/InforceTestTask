using AutoMapper;
using FluentResults;
using Inforce.BLL.DTO.Shorten;
using Inforce.DAL.Entities.Shortener;
using Inforce.DAL.Persistence;
using Inforce.DAL.Repositories.Interfaces.Base;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Inforce.BLL.MediatR.Shorten.Create;

public class CreateShortenHandler : IRequestHandler<CreateShortenCommand, Result<ShortenDTO>>
{
    private readonly IMapper _mapper;
    private readonly IRepositoryWrapper _repositoryWrapper;
    private readonly MyDbContext _dbContext;
    private readonly IHttpContextAccessor _httpContextAccessor;

    private readonly Random _random = new();
    private const int NumberOfCharsInShortLink = 7;
    private const string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890";

    public CreateShortenHandler(IMapper mapper, IRepositoryWrapper repositoryWrapper, MyDbContext dbContext, IHttpContextAccessor httpContextAccessor)
    {
        _mapper = mapper;
        _repositoryWrapper = repositoryWrapper;
        _dbContext = dbContext;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<string> GenerateUniqueCode()
    {
        var codeChars = new char[NumberOfCharsInShortLink];

        while (true)
        {
            for (var i = 0; i < NumberOfCharsInShortLink; i++)
            {
                var randomIndex = _random.Next(Alphabet.Length - 1);

                codeChars[i] = Alphabet[randomIndex];
            }

            var code = new string(codeChars);

            if (! await _dbContext.ShortenedUrls.AnyAsync(s => s.Code == code))
            {
                return code;
            }
        }
    }

    public async Task<Result<ShortenDTO>> Handle(CreateShortenCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var url = _mapper.Map<ShortenedUrl>(request.shortenUrl);
            var httpContext = _httpContextAccessor.HttpContext;
            var codeString = await GenerateUniqueCode();
            var newUrl = $"{httpContext.Request.Scheme}://{httpContext.Request.Host}/api/{codeString}";
            var shorts = new ShortenedUrl
            {
                LongUrl = url.LongUrl,
                Code = codeString,
                ShortUrl = newUrl,
                CreatedOnUtc = DateTime.Now,
            };
            var createdUrl = await _repositoryWrapper.ShortenedUrlRepository.CreateAsync(shorts);
            await _repositoryWrapper.SaveChangesAsync();
            return Result.Ok(_mapper.Map<ShortenDTO>(createdUrl));
        }
        catch (Exception ex)
        {
            return Result.Fail(ex.Message);
        }
    }
}