using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BackendAPI.Models
{
    public partial class mydbaContext : DbContext
    {
        public mydbaContext()
        {
        }

        public mydbaContext(DbContextOptions<mydbaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Donacija> Donacija { get; set; }
        public virtual DbSet<Donor> Donor { get; set; }
        public virtual DbSet<DozaKrvi> DozaKrvi { get; set; }
        public virtual DbSet<Isporuka> Isporuka { get; set; }
        public virtual DbSet<Kontakt> Kontakt { get; set; }
        public virtual DbSet<LjekarskiPregled> LjekarskiPregled { get; set; }
        public virtual DbSet<Lokacija> Lokacija { get; set; }
        public virtual DbSet<Magacin> Magacin { get; set; }
        public virtual DbSet<Potraznja> Potraznja { get; set; }
        public virtual DbSet<Radnik> Radnik { get; set; }
        public virtual DbSet<VazeceDoze> VazeceDoze { get; set; }
        public virtual DbSet<Zahtjev> Zahtjev { get; set; }
        public virtual DbSet<ZdravstvenaUstanova> ZdravstvenaUstanova { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=;database=mydba");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Donacija>(entity =>
            {
                entity.ToTable("donacija");

                entity.HasIndex(e => e.DonorId)
                    .HasName("IX_Relationship9");

                entity.Property(e => e.DonacijaId)
                    .HasColumnName("donacija_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DatumDoniranja)
                    .HasColumnName("datum_doniranja")
                    .HasColumnType("date");

                entity.Property(e => e.DoniranaKolicinaMl)
                    .HasColumnName("donirana_kolicina_ml")
                    .HasColumnType("smallint(6)")
                    .HasDefaultValueSql("'450'");

                entity.Property(e => e.DonorId)
                    .HasColumnName("donor_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TipDonacije)
                    .HasColumnName("tip_donacije")
                    .HasMaxLength(24)
                    .IsUnicode(false);

                entity.HasOne(d => d.Donor)
                    .WithMany(p => p.Donacija)
                    .HasForeignKey(d => d.DonorId)
                    .HasConstraintName("Relationship9");
            });

            modelBuilder.Entity<Donor>(entity =>
            {
                entity.ToTable("donor");

                entity.Property(e => e.DonorId)
                    .HasColumnName("donor_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DatumNajranijegSledecegDoniranja)
                    .HasColumnName("datum_najranijeg_sledeceg_doniranja")
                    .HasColumnType("date");

                entity.Property(e => e.DatumPoslednjegDoniranja)
                    .HasColumnName("datum_poslednjeg_doniranja")
                    .HasColumnType("date");

                entity.Property(e => e.DatumRodjenja)
                    .HasColumnName("datum_rodjenja")
                    .HasColumnType("date");

                entity.Property(e => e.Ime)
                    .HasColumnName("ime")
                    .HasMaxLength(24)
                    .IsUnicode(false);

                entity.Property(e => e.KrvnaGrupaDonor)
                    .HasColumnName("krvna_grupa_donor")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Lozinka)
                    .HasColumnName("lozinka")
                    .HasMaxLength(24)
                    .IsUnicode(false);

                entity.Property(e => e.Pol)
                    .HasColumnName("pol")
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.Property(e => e.Prezime)
                    .HasColumnName("prezime")
                    .HasMaxLength(24)
                    .IsUnicode(false);

                entity.Property(e => e.RegistarskiBroj)
                    .HasColumnName("registarski_broj")
                    .HasMaxLength(24)
                    .IsUnicode(false);

                entity.Property(e => e.TipPoslednjegDoniranja)
                    .HasColumnName("tip_poslednjeg_doniranja")
                    .HasMaxLength(24)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DozaKrvi>(entity =>
            {
                entity.ToTable("doza_krvi");

                entity.HasIndex(e => e.DonacijaId)
                    .HasName("IX_Relationship11");

                entity.HasIndex(e => e.IsporukaId)
                    .HasName("IX_Relationship29");

                entity.HasIndex(e => e.MagacinId)
                    .HasName("IX_Relationship14");

                entity.Property(e => e.DozaKrviId)
                    .HasColumnName("doza_krvi_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DatumIstekaRoka)
                    .HasColumnName("datum_isteka_roka")
                    .HasColumnType("date");

                entity.Property(e => e.DonacijaId)
                    .HasColumnName("donacija_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IsporukaId)
                    .HasColumnName("isporuka_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IstekaoRok)
                    .HasColumnName("istekao_rok")
                    .HasColumnType("smallint(6)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.KolicinaKrvnogDerivataMl)
                    .HasColumnName("kolicina_krvnog_derivata_ml")
                    .HasColumnType("smallint(6)")
                    .HasDefaultValueSql("'450'");

                entity.Property(e => e.KrvnaGrupaDoza)
                    .HasColumnName("krvna_grupa_doza")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.MagacinId)
                    .HasColumnName("magacin_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SerijskaOznaka)
                    .HasColumnName("serijska_oznaka")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.TipKrvnogDerivata)
                    .HasColumnName("tip_krvnog_derivata")
                    .HasMaxLength(24)
                    .IsUnicode(false);

                entity.HasOne(d => d.Donacija)
                    .WithMany(p => p.DozaKrvi)
                    .HasForeignKey(d => d.DonacijaId)
                    .HasConstraintName("Relationship11");

                entity.HasOne(d => d.Isporuka)
                    .WithMany(p => p.DozaKrvi)
                    .HasForeignKey(d => d.IsporukaId)
                    .HasConstraintName("Relationship29");

                entity.HasOne(d => d.Magacin)
                    .WithMany(p => p.DozaKrvi)
                    .HasForeignKey(d => d.MagacinId)
                    .HasConstraintName("Relationship14");
            });

            modelBuilder.Entity<Isporuka>(entity =>
            {
                entity.ToTable("isporuka");

                entity.HasIndex(e => e.ZahtjevId)
                    .HasName("IX_Relationship28");

                entity.Property(e => e.IsporukaId)
                    .HasColumnName("isporuka_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DatumIsporuke)
                    .HasColumnName("datum_isporuke")
                    .HasColumnType("date");

                entity.Property(e => e.ZahtjevId)
                    .HasColumnName("zahtjev_ID")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Zahtjev)
                    .WithMany(p => p.Isporuka)
                    .HasForeignKey(d => d.ZahtjevId)
                    .HasConstraintName("Relationship28");
            });

            modelBuilder.Entity<Kontakt>(entity =>
            {
                entity.ToTable("kontakt");

                entity.HasIndex(e => e.DonorId)
                    .HasName("IX_Relationship32");

                entity.HasIndex(e => e.LokacijaId)
                    .HasName("IX_Relationship16");

                entity.HasIndex(e => e.RadnikId)
                    .HasName("IX_Relationship31");

                entity.HasIndex(e => e.ZdravstvenaUstanovaId)
                    .HasName("IX_Relationship27");

                entity.Property(e => e.KontaktId)
                    .HasColumnName("kontakt_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.BrojTelefona)
                    .HasColumnName("broj_telefona")
                    .HasMaxLength(24)
                    .IsUnicode(false);

                entity.Property(e => e.DonorId)
                    .HasColumnName("donor_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(48)
                    .IsUnicode(false);

                entity.Property(e => e.LokacijaId)
                    .HasColumnName("lokacija_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.RadnikId)
                    .HasColumnName("radnik_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ZdravstvenaUstanovaId)
                    .HasColumnName("zdravstvena_ustanova_ID")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Donor)
                    .WithMany(p => p.Kontakt)
                    .HasForeignKey(d => d.DonorId)
                    .HasConstraintName("Relationship32");

                entity.HasOne(d => d.Lokacija)
                    .WithMany(p => p.Kontakt)
                    .HasForeignKey(d => d.LokacijaId)
                    .HasConstraintName("Relationship16");

                entity.HasOne(d => d.Radnik)
                    .WithMany(p => p.Kontakt)
                    .HasForeignKey(d => d.RadnikId)
                    .HasConstraintName("Relationship31");

                entity.HasOne(d => d.ZdravstvenaUstanova)
                    .WithMany(p => p.Kontakt)
                    .HasForeignKey(d => d.ZdravstvenaUstanovaId)
                    .HasConstraintName("Relationship27");
            });

            modelBuilder.Entity<LjekarskiPregled>(entity =>
            {
                entity.ToTable("ljekarski_pregled");

                entity.HasIndex(e => e.DonacijaId)
                    .HasName("IX_Relationship33");

                entity.Property(e => e.LjekarskiPregledId)
                    .HasColumnName("ljekarski_pregled_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DonacijaId)
                    .HasColumnName("donacija_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.KrvniPritisak)
                    .HasColumnName("krvni_pritisak")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.Napomena)
                    .HasColumnName("napomena")
                    .HasMaxLength(48)
                    .IsUnicode(false);

                entity.Property(e => e.NivoHemoglobina)
                    .HasColumnName("nivo_hemoglobina")
                    .HasColumnType("decimal(5,2)");

                entity.Property(e => e.Puls)
                    .HasColumnName("puls")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.Temperatura)
                    .HasColumnName("temperatura")
                    .HasColumnType("decimal(5,2)");

                entity.Property(e => e.TezinaKg)
                    .HasColumnName("tezina_kg")
                    .HasColumnType("smallint(6)");

                entity.HasOne(d => d.Donacija)
                    .WithMany(p => p.LjekarskiPregled)
                    .HasForeignKey(d => d.DonacijaId)
                    .HasConstraintName("Relationship33");
            });

            modelBuilder.Entity<Lokacija>(entity =>
            {
                entity.ToTable("lokacija");

                entity.Property(e => e.LokacijaId)
                    .HasColumnName("lokacija_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Adresa)
                    .HasColumnName("adresa")
                    .HasMaxLength(42)
                    .IsUnicode(false);

                entity.Property(e => e.Mjesto)
                    .HasColumnName("mjesto")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.PostanskiBroj)
                    .HasColumnName("postanski_broj")
                    .HasMaxLength(12)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Magacin>(entity =>
            {
                entity.ToTable("magacin");

                entity.HasIndex(e => e.LokacijaId)
                    .HasName("IX_Relationship13");

                entity.Property(e => e.MagacinId)
                    .HasColumnName("magacin_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.BrojDozaEritrocita)
                    .HasColumnName("broj_doza_eritrocita")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.BrojDozaKrvi)
                    .HasColumnName("broj_doza_krvi")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.BrojDozaPlazme)
                    .HasColumnName("broj_doza_plazme")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.BrojDozaTrombocita)
                    .HasColumnName("broj_doza_trombocita")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.KrvnaGrupaMagacin)
                    .HasColumnName("krvna_grupa_magacin")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.LokacijaId)
                    .HasColumnName("lokacija_ID")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Lokacija)
                    .WithMany(p => p.Magacin)
                    .HasForeignKey(d => d.LokacijaId)
                    .HasConstraintName("Relationship13");
            });

            modelBuilder.Entity<Potraznja>(entity =>
            {
                entity.ToTable("potraznja");

                entity.HasIndex(e => e.MagacinId)
                    .HasName("IX_Relationship21");

                entity.Property(e => e.PotraznjaId)
                    .HasColumnName("potraznjaID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.KrvnaGrupaPotraznja)
                    .HasColumnName("krvna_grupa_potraznja")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.MagacinId)
                    .HasColumnName("magacin_ID")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Magacin)
                    .WithMany(p => p.Potraznja)
                    .HasForeignKey(d => d.MagacinId)
                    .HasConstraintName("Relationship21");
            });

            modelBuilder.Entity<Radnik>(entity =>
            {
                entity.ToTable("radnik");

                entity.Property(e => e.RadnikId)
                    .HasColumnName("radnik_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Admin)
                    .HasColumnName("admin")
                    .HasColumnType("smallint(6)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.DatumRodjenja)
                    .HasColumnName("datum_rodjenja")
                    .HasColumnType("date");

                entity.Property(e => e.DatumZaposlenja)
                    .HasColumnName("datum_zaposlenja")
                    .HasColumnType("date");

                entity.Property(e => e.Ime)
                    .HasColumnName("ime")
                    .HasMaxLength(24)
                    .IsUnicode(false);

                entity.Property(e => e.KorisnickoIme)
                    .HasColumnName("korisnicko_ime")
                    .HasMaxLength(24)
                    .IsUnicode(false);

                entity.Property(e => e.Lozinka)
                    .HasColumnName("lozinka")
                    .HasMaxLength(24)
                    .IsUnicode(false);

                entity.Property(e => e.Prezime)
                    .HasColumnName("prezime")
                    .HasMaxLength(24)
                    .IsUnicode(false);

                entity.Property(e => e.RadnoMjesto)
                    .HasColumnName("radno_mjesto")
                    .HasMaxLength(32)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VazeceDoze>(entity =>
            {
                entity.HasKey(e => e.DozaKrviId)
                    .HasName("PRIMARY");

                entity.ToTable("vazece_doze");

                entity.HasIndex(e => e.DozaKrviId)
                    .HasName("IX_Relationship30");

                entity.Property(e => e.DozaKrviId)
                    .HasColumnName("doza_krvi_ID")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.DozaKrvi)
                    .WithOne(p => p.VazeceDoze)
                    .HasForeignKey<VazeceDoze>(d => d.DozaKrviId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Relationship30");
            });

            modelBuilder.Entity<Zahtjev>(entity =>
            {
                entity.ToTable("zahtjev");

                entity.HasIndex(e => e.ZdravstvenaUstanovaId)
                    .HasName("IX_Relationship24");

                entity.Property(e => e.ZahtjevId)
                    .HasColumnName("zahtjev_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DatumPodnosenjaZahtjeva)
                    .HasColumnName("datum_podnosenja_zahtjeva")
                    .HasColumnType("date");

                entity.Property(e => e.KrvnaGrupaZahtjev)
                    .HasColumnName("krvna_grupa_zahtjev")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Napomena)
                    .HasColumnName("napomena")
                    .HasMaxLength(48)
                    .IsUnicode(false);

                entity.Property(e => e.TipKrvnogDerivata)
                    .HasColumnName("tip_krvnog_derivata")
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.ZahtjevPrihvacen)
                    .HasColumnName("zahtjev_prihvacen")
                    .HasColumnType("smallint(6)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.ZahtjevanaKolicina)
                    .HasColumnName("zahtjevana_kolicina")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.ZdravstvenaUstanovaId)
                    .HasColumnName("zdravstvena_ustanova_ID")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.ZdravstvenaUstanova)
                    .WithMany(p => p.Zahtjev)
                    .HasForeignKey(d => d.ZdravstvenaUstanovaId)
                    .HasConstraintName("Relationship24");
            });

            modelBuilder.Entity<ZdravstvenaUstanova>(entity =>
            {
                entity.ToTable("zdravstvena_ustanova");

                entity.Property(e => e.ZdravstvenaUstanovaId)
                    .HasColumnName("zdravstvena_ustanova_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Naziv)
                    .HasColumnName("naziv")
                    .HasMaxLength(48)
                    .IsUnicode(false);

                entity.Property(e => e.VerifikacioniKod)
                    .HasColumnName("verifikacioni_kod")
                    .HasMaxLength(16)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
