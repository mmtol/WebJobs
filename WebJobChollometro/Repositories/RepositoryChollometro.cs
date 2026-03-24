using Microsoft.EntityFrameworkCore;
using WebJobChollometro.Data;

namespace WebJobChollometro.Repositories
{
    public class RepositoryChollometro
    {
        private ChollometroContext context;

        public RepositoryChollometro(ChollometroContext context)
        {
            this.context = context;
        }

        private async Task<int> GetMaxIdCholloAsync()
        {
            if (context.Chollos.Count() == 0)
            {
                return 1;
            }
            else
            {
                return await context.Chollos.MaxAsync(x => x.IdChollo) + 1;
            }
        }
    }
}
