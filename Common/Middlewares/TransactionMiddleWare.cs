
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
            await _context.Database.BeginTransactionAsync();


            // wrap the response
            var originalBody = context.Response.Body;
            using var memStream = new MemoryStream();
            context.Response.Body = memStream;
            try
            {
                await next(context);

                memStream.Position = 0;
                var reader = new StreamReader(memStream);
                var responseBody = await reader.ReadToEndAsync();


                if (responseBody.Contains("\"success\":false", StringComparison.OrdinalIgnoreCase))
                {
                    // حصل Failure → Rollback
                    await _context.Database.RollbackTransactionAsync();
                }
                else
                {
                    await _context.Database.CommitTransactionAsync();
                }

                // رجّع الـ response للـ client
                memStream.Position = 0;
                await memStream.CopyToAsync(originalBody);

                //await _context.Database.BeginTransactionAsync();
                //await next(context);
                //await _context.Database.CommitTransactionAsync();
            }
            catch (Exception ex) 
            {
                await _context.Database.RollbackTransactionAsync();
                throw;
            }
            finally
            {
                context.Response.Body = originalBody;
            }
        }
    }
}
