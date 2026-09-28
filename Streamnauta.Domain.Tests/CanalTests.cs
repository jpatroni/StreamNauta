
using System;
using Streamnauta.Domain.Entities;
using Xunit;

namespace Streamnauta.Domain.Tests;

public class CanalTests
{
    // PRUEBA 1
    [Fact]
    public void CrearCanal_ConDatosValidos_GuardaDatos()
    {
        // ARRANGE
        string nombre = "JuliStreams";
        string plataforma = "Twitch";
        string idExterno = "12345";

        // ACT
        Canal canal = new Canal(
            nombre,
            plataforma,
            idExterno);

        // ASSERT
        Assert.Equal(nombre, canal.Nombre);
        Assert.Equal(plataforma, canal.Plataforma);
        Assert.Equal(idExterno, canal.IdExterno);
        Assert.NotEqual(Guid.Empty, canal.Id);
    }

    // PRUEBA 2
    [Fact]
    public void CrearCanal_SinNombre_LanzaExcepcion()
    {
        // ARRANGE
        string nombre = "";
        string plataforma = "Twitch";
        string idExterno = "12345";

        // ACT Y ASSERT
        Assert.Throws<ArgumentException>(() =>
        {
            new Canal(nombre, plataforma, idExterno);
        });
    }


    [Fact]
    public void CambiarNombre_ConNombreValido_ActualizaNombre()
    {
        // ARRANGE
        Canal canal = new Canal(
            "JuliStreams",
            "Twitch",
            "12345"
        );

        // ACT
        canal.CambiarNombre("JuliGaming");
        // ASSERT
        // Acá tenés que comprobar el nuevo nombre
        Assert.Equal("JuliGaming", canal.Nombre);
    }



    [Fact]
    public void CambiarNombre_ConNombreVacio_LanzaExcepcion()
    {
        // ARRANGE
        Canal canal = new Canal(
            "JuliStreams",
            "Twitch",
            "12345"
        );

        // ACT Y ASSERT
        Assert.Throws<ArgumentException>(() =>
        {
            canal.CambiarNombre("");
        });

        Assert.Equal("JuliStreams", canal.Nombre);

        // Completá la prueba acá.
    }


}


