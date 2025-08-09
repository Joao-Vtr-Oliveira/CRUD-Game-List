using CRUD_Game_List.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

public class ApiExceptionFilter : IExceptionFilter
{
	public void OnException(ExceptionContext context)
	{
		var ex = context.Exception;
		var problem = new ProblemDetails { Detail = ex.Message };
		int status;

		switch (ex)
		{
			case DuplicateCategoryNameException:
				status = StatusCodes.Status409Conflict;
				problem.Title = "Conflict";
				break;

			case CategoryNotFoundException:
				status = StatusCodes.Status404NotFound;
				problem.Title = "Not Found";
				break;

			case ArgumentException:
				status = StatusCodes.Status400BadRequest;
				problem.Title = "Bad Request";
				break;

			default:
				status = StatusCodes.Status500InternalServerError;
				problem.Title = "Internal Server Error";
				problem.Detail = "An unexpected error occurred.";
				break;
		}

		problem.Status = status;
		context.Result = new ObjectResult(problem) { StatusCode = status };
		context.ExceptionHandled = true;
	}
}
