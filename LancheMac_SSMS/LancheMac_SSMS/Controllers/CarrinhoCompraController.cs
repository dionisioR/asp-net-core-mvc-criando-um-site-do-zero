﻿using LancheMac_SSMS.Models;
using LancheMac_SSMS.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using LancheMac_SSMS.ViewModels;

namespace LancheMac_SSMS.Controllers {
    public class CarrinhoCompraController : Controller {

        private readonly ILancheRepository _lancheRepository;
        private readonly CarrinhoCompra _carrinhoCompra;

        public CarrinhoCompraController(ILancheRepository lancheRepository, CarrinhoCompra carrinhoCompra) {
            _lancheRepository = lancheRepository;
            _carrinhoCompra = carrinhoCompra;
        }

        public IActionResult Index() {
            var itens = _carrinhoCompra.GetCarrinhoCompraItens();
            _carrinhoCompra.CarrinhoCompraItems = itens;

            var carrinhoCompraVm = new CarrinhoCompraViewModel {
                CarrinhoCompra = _carrinhoCompra,
                CarrinhoCompraTotal = _carrinhoCompra.GetCarrinhoCompraTotal()
            };
            return View(carrinhoCompraVm);
        }

        public IActionResult AdicionarItemNoCarrinhoCompra(int lancheId) {
            var lancheSelecionado = _lancheRepository.Lanches.FirstOrDefault(p => p.LancheId == lancheId);
            if(lancheSelecionado != null) {
                _carrinhoCompra.AdicionarAoCarrinho(lancheSelecionado);
            }
            return RedirectToAction("Index");
        }

        public IActionResult RemoverItemNoCarrinhoCompra(int lancheId) {
            var lancheSelecionado = _lancheRepository.Lanches.FirstOrDefault(p => p.LancheId == lancheId);
            if (lancheSelecionado != null) {
                _carrinhoCompra.RemoverDoCarrinho(lancheSelecionado);
            }
            return RedirectToAction("Index");
        }
    }
}
