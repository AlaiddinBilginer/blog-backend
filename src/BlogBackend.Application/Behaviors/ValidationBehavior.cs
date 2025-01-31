using BlogBackend.Application.Common.Models.Errors;
using BlogBackend.Application.Common.Models.Responses;
using FluentValidation;
using MediatR;

namespace BlogBackend.Application.Behaviors;

public sealed class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, ResponseDto<TResponse>>
    where TRequest : IRequest<ResponseDto<TResponse>>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<ResponseDto<TResponse>> Handle(TRequest request, RequestHandlerDelegate<ResponseDto<TResponse>> next, CancellationToken cancellationToken)
    {

        if(_validators.Any()) 
        {
            var context = new ValidationContext<TRequest>(request);

            var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));

            var failures = validationResults
                .Where(result => result.Errors.Any())            
                .SelectMany(result => result.Errors)
                .Where(f => f != null)
                .Select(f => new ValidationError(f.PropertyName, f.ErrorMessage))
                .ToList();

            if(failures.Any()) 
                return ResponseDto<TResponse>.Error("Validasyon hatası", failures);
        }

        return await next();
    }
}
