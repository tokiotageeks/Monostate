using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;

namespace MonoState.Test
{
    [TestClass]
    public class MonoStateTest
    {
        private const string NewUser = "Don Ramón";
        private IConfiguration state;


        [TestInitialize]
        public void antes_de_cada_prueba()
        {
            //Asegurarse de mantener el usuario "el chavo del 8" antes de cada prueba
            state = new MonoStateConfiguration
                {
                    UserName = "El chavo del 8"
                };
        }

        [TestMethod]
        public void cuando_el_valor_se_asigna_a_una_variable_temporal_esta_no_se_actualiza()
        {
            IConfiguration stateTwo = new MonoStateConfiguration();
            string tempUser = state.UserName;
            stateTwo.UserName = NewUser;

            Assert.AreNotEqual(tempUser, stateTwo.UserName);
        }

        [TestMethod]
        public void cuando_se_actualiza_y_luego_se_crea_un_segundo_ms_este_tiene_el_nuevo_valor()
        {
            state.UserName = NewUser;
            IConfiguration stateTwo = new MonoStateConfiguration();

            Assert.AreSame(stateTwo.UserName, NewUser);
        }

        [TestMethod]
        public void cuando_se_crea_un_segundo_ms_y_semodifica_el_segundo_entonces_se_actualiza_la_primer_instancia()
        {
            IConfiguration stateTwo = new MonoStateConfiguration();
            stateTwo.UserName = NewUser;

            Assert.AreSame(state.UserName, NewUser);
        }

        [TestMethod]
        public void cuando_se_crean_son_referencias_diferentes_del_tipo_monostate()
        {
            IConfiguration stateTwo = new MonoStateConfiguration();

            Assert.AreNotSame(state, stateTwo);
        }

        [TestMethod]
        public void mantiene_la_misma_referencia_del_estado()
        {
            IConfiguration stateTwo = new MonoStateConfiguration();
            Assert.AreSame(stateTwo.UserName, state.UserName);
        }

        [TestMethod]
        public void esto_si_que_no_lo_haces_con_un_singleton()
        {
            //Arrange
            const string DonyaClotilde = "La bruja del 71";
            var mockConfiguracion = new Mock<IConfiguration>();
            mockConfiguracion.Setup(conf => conf.UserName).Returns(DonyaClotilde);
            var sut = new ClaseNegocio(mockConfiguracion.Object);

            //Act
            var user = sut.GetActiveUserName();

            //Assertion
            Assert.AreEqual(user, DonyaClotilde);
        }
    }
}