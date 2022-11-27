using ChurchPresenter.Shared;

namespace ChurchPresenter.Core.Models;

public class HymnBook : Entity
{
    public string Name { get; set; }
    public int Id { get; set; }
    public string Abbreviation { get; set; }
    public string ChurchName { get; set; }
}