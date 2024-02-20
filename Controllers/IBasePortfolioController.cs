using System.Collections.ObjectModel;
using Microsoft.AspNetCore.Mvc;

public interface IBasePortfolioController<T, TDto, TCreateDto, TUpdateDto, TIdentityType> 
    // Table identifier key type - int|string
    where TIdentityType : IEquatable<TIdentityType>
{
    public Task<ActionResult<Collection<TDto>>> Get();
    public Task<ActionResult<TDto>> Find(TIdentityType id);
    public Task<ActionResult<TDto>> Create(TCreateDto createTDto);
    public Task<ActionResult<TDto>> Update(TIdentityType id, TUpdateDto updateTDto);
    public Task<ActionResult> Delete(TIdentityType id);
}