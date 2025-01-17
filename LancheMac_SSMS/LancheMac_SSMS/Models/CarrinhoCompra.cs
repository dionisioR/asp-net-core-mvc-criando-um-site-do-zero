using LancheMac_SSMS.Context;
using Microsoft.EntityFrameworkCore;

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

        public void AdicionarAoCarrinho(Lanche lanche) {
            var carrinhoCompraItem = _context.CarrinhoCompraItens.SingleOrDefault(
                    s => s.Lanche.LancheId == lanche.LancheId &&
                    s.CarrinhoCompraId == CarrinhoCompraId
                );

            if (carrinhoCompraItem == null) {
                carrinhoCompraItem = new CarrinhoCompraItem {
                    CarrinhoCompraId = CarrinhoCompraId,
                    Lanche = lanche,
                    Quantidade = 1
                };
                _context.CarrinhoCompraItens.Add(carrinhoCompraItem);
            }
            else {
                carrinhoCompraItem.Quantidade = 1;
            }
            _context.SaveChanges();
        }

        public int RemoverDoCarrinho(Lanche lanche) {
            var carrinhoCmpraItem = _context.CarrinhoCompraItens.SingleOrDefault(
                    s => s.Lanche.LancheId == lanche.LancheId &&
                    s.CarrinhoCompraId == CarrinhoCompraId
                );

            var quantidadeLocal = 0;

            if(carrinhoCmpraItem != null) {
                if(carrinhoCmpraItem.Quantidade > 1) {
                    carrinhoCmpraItem.Quantidade--;
                    quantidadeLocal = carrinhoCmpraItem.Quantidade;
                }
                else {
                    _context.CarrinhoCompraItens.Remove(carrinhoCmpraItem);
                }
            }
            _context.SaveChanges();
            return quantidadeLocal;
        }

        public List<CarrinhoCompraItem> GetCarrinhoCompraItens() {
            return CarrinhoCompraItems ?? (CarrinhoCompraItems = _context.CarrinhoCompraItens.Where(c => c.CarrinhoCompraId == CarrinhoCompraId).Include(s => s.Lanche).ToList());
        }

        public void LimparCarrinho() {
            var carrinhoItens = _context.CarrinhoCompraItens.Where(carrinho => carrinho.CarrinhoCompraId == CarrinhoCompraId);

            _context.CarrinhoCompraItens.RemoveRange(carrinhoItens);
            _context.SaveChanges();
        }

        public decimal GetCarrinhoCompraTotal() {
            var total = _context.CarrinhoCompraItens.Where(c => c.CarrinhoCompraId == CarrinhoCompraId).Select(c => c.Lanche.Preco * c.Quantidade).Sum();
            return total;
        }
    }
}
