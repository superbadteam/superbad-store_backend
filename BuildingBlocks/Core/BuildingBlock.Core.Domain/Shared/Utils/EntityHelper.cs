using System.Security.Cryptography;
using System.Text;
using BuildingBlock.Core.Domain.Exceptions;
using BuildingBlock.Core.Domain.Repositories;
using BuildingBlock.Core.Domain.Specifications.Abstractions;
using BuildingBlock.Core.Domain.Specifications.Implementations;

namespace BuildingBlock.Core.Domain.Shared.Utils;

public static class EntityHelper
{
    public static async Task<T> GetOrThrowAsync<T>(Specification<T>? specification, EntityNotFoundException exception,
        IReadOnlyRepository<T> readOnlyRepository) where T : IEntity
    {
        return Optional<T>.Of(await readOnlyRepository.GetAnyAsync(specification)).ThrowIfNotExist(exception).Get();
    }

    public static async Task<T> GetOrThrowAsync<T>(Guid id, EntityNotFoundException exception,
        IReadOnlyRepository<T> readOnlyRepository) where T : IEntity
    {
        var specification = new EntityIdSpecification<T>(id);

        return Optional<T>.Of(await readOnlyRepository.GetAnyAsync(specification)).ThrowIfNotExist(exception).Get();
    }

    public static async Task ThrowIfNotExistAsync<T>(Guid id, EntityNotFoundException exception,
        IReadOnlyRepository<T> readOnlyRepository)
        where T : IEntity
    {
        var specification = new EntityIdSpecification<T>(id);

        Optional<bool>.Of(await readOnlyRepository.CheckIfExistAsync(specification)).ThrowIfNotExist(exception);
    }

    public static async Task ThrowIfNotExistAsync<T>(Specification<T>? specification, EntityNotFoundException exception,
        IReadOnlyRepository<T> readOnlyRepository)
        where T : IEntity
    {
        Optional<bool>.Of(await readOnlyRepository.CheckIfExistAsync(specification)).ThrowIfNotExist(exception);
    }

    public static async Task ThrowIfExistAsync<T>(Guid id, EntityConflictException exception,
        IReadOnlyRepository<T> readOnlyRepository)
        where T : IEntity
    {
        var specification = new EntityIdSpecification<T>(id);

        Optional<bool>.Of(await readOnlyRepository.CheckIfExistAsync(specification)).ThrowIfExist(exception);
    }

    public static async Task ThrowIfExistAsync<T>(Specification<T>? specification, EntityConflictException exception,
        IReadOnlyRepository<T> readOnlyRepository)
        where T : IEntity
    {
        Optional<bool>.Of(await readOnlyRepository.CheckIfExistAsync(specification)).ThrowIfExist(exception);
    }

    public static Guid ToGuid(this string str)
    {
        if (str == null)
            throw new ArgumentNullException(nameof(str));
        var hash = SHA256.HashData(Encoding.UTF8.GetBytes(str));

        var guidBytes = new byte[16];
        Array.Copy(hash, guidBytes, 16);

        return new Guid(guidBytes);
    }
}