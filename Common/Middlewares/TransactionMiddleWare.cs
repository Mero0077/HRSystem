
using HRSystem.Common.AppDbContext;

namespace HRSystem.Common.Middlewares
{
    public class TransactionMiddleWare : IMiddleware
    {
        private readonly ApplicationDbContext _context;

        public TransactionMiddleWare(ApplicationDbContext context) 
        {
            this._context = context;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await _context.Database.BeginTransactionAsync();
                await next(context);
                await _context.Database.CommitTransactionAsync();
            }
            catch (Exception ex) 
            {
                await _context.Database.RollbackTransactionAsync();
                throw;
            }
        }
    }
}
