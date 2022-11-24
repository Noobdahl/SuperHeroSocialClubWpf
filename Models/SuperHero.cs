namespace SuperHeroSocialClubWpf.Models;

public partial class SuperHero
{
    public int SuperHeroId { get; set; }

    public string Name { get; set; } = null!;

    public string SecretIdentity { get; set; } = null!;

    public string? Picture { get; set; }

    public string? SuperPower { get; set; }
}
