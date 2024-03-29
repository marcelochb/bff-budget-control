using BudgetControl.Application.Categories.Contracts;
using ErrorOr;
using MediatR;

namespace BudgetControl.Application.Categories.Commands;

public record CategoryCreateCommand(string Name,
                                          float Goal,
                                          string Color,
                                          Guid LedgerId) : IRequest<ErrorOr<CategoryResult>>;