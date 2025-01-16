using LancheMac_SSMS.Context;

namespace LancheMac_SSMS.Models {
    public class CarrinhoCompra {

        private readonly AppDbContext _context;

        public CarrinhoCompra(AppDbContext context) {
            _context = context;
        }
        public string CarrinhoCompraId { get; set; }
        public List<CarrinhoCompraItem> CarrinhoCompraItems { get; set; }

        public static CarrinhoCompra GetCarrinho(IServiceProvider service) {
            // define uma sessão
            ISession session = service.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            // obtem um serviço do tipo do nosso contexto
            var context = service.GetService<AppDbContext>();

            // obtem ou gera o Id do carrinho
            string carrinhoId = session.GetString("CarrinhoId")?? Guid.NewGuid().ToString();

            // atribui o id do carrinho na sessão
            session.SetString("CarrinhoId", carrinhoId);

            // retorna o carrinho com o contexto e o ID atribuido ou obtido
            return new CarrinhoCompra(context) {
                CarrinhoCompraId = carrinhoId,
            };
        }



    }
}
