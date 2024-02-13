using BudgetControl.Application.Categories.Commands;
using BudgetControl.Application.Categories.Contracts;
using BudgetControl.Contracts.Categories.Request;
using BudgetControl.Contracts.Categories.Response;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BudgetControl.Api.Controllers;

[Route("[controller]")]
[Authorize]
public class CategoryController: ApiController
{
    private readonly IMapper _mapper;
    private readonly ISender _mediator;

    public CategoryController(IMapper mapper, ISender mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    // [HttpGet]
    // public async Task<IActionResult> ListCategories(string ledgerId)
    // {
    //     ErrorOr<LedgerCategoryListResult> categoryListResult = await _mediator.Send(new CategoryListQuery(ledgerId));
    //     return categoryListResult.Match(
    //         categoryListResult => Ok(_mapper.Map<LedgerCategoryListResponse>(categoryListResult)),
    //         errors => Problem(errors)
    //     );
    // }

    // [HttpGet("{id}")]
    // public async Task<IActionResult> GetCategory(string id)
    // {
    //     ErrorOr<LedgerCategory> category = await _mediator.Send(new CategoryGetQuery(id));
    //     return category.Match(
    //         category => Ok(_mapper.Map<LedgerCategoryResponse>(category)),
    //         errors => Problem(errors)
    //     );
    // }

    [HttpPost]
    public async Task<IActionResult> CreateCategory([FromBody] CategoryRequest request)
    {
        var command = _mapper.Map<CategoryCreateCommand>(request with { 
            LedgerId = (string?)HttpContext.User.Claims.First(x => x.Type == "ledgerId").Value  
        });
        ErrorOr<CategoryResult> category = await _mediator.Send(command);
        return category.Match(
            category => Ok(_mapper.Map<CategoryResponse>(category)),
            errors => Problem(errors)
        );
    }
}
