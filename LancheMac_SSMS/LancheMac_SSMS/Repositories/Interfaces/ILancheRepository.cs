using LancheMac_SSMS.Models;

namespace LancheMac_SSMS.Repositories.Interfaces {
    public interface ILancheRepository {
        IEnumerable<Lanche> Lanches { get; }
        IEnumerable<Lanche> LanchesPreferidos { get; }
        Lanche GetLancheById(int lancheId);

    }
}
