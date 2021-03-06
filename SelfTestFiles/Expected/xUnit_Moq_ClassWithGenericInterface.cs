using Moq;
using System;
using System.Collections.Generic;
using UnitBoilerplate.Sandbox.Classes;
using UnitBoilerplate.Sandbox.Classes.Cases;
using Xunit;

namespace UnitTestBoilerplate.SelfTest.Cases
{
	public class ClassWithGenericInterfaceTests : IDisposable
	{
		private MockRepository mockRepository;

		private Mock<IInterface3> mockInterface3;
		private Mock<IGenericInterface<List<int>>> mockGenericInterfaceListInt;
		private Mock<IGenericInterface<List<ISomeOtherInterface>>> mockGenericInterfaceListSomeOtherInterface;
		private Mock<IGenericInterface<bool>> mockGenericInterfaceBool;
		private Mock<IGenericInterface<List<string>>> mockGenericInterfaceListString;
		private Mock<ISomeInterface> mockSomeInterface;

		public ClassWithGenericInterfaceTests()
		{
			this.mockRepository = new MockRepository(MockBehavior.Strict);

			this.mockInterface3 = this.mockRepository.Create<IInterface3>();
			this.mockGenericInterfaceListInt = this.mockRepository.Create<IGenericInterface<List<int>>>();
			this.mockGenericInterfaceListSomeOtherInterface = this.mockRepository.Create<IGenericInterface<List<ISomeOtherInterface>>>();
			this.mockGenericInterfaceBool = this.mockRepository.Create<IGenericInterface<bool>>();
			this.mockGenericInterfaceListString = this.mockRepository.Create<IGenericInterface<List<string>>>();
			this.mockSomeInterface = this.mockRepository.Create<ISomeInterface>();
		}

		public void Dispose()
		{
			this.mockRepository.VerifyAll();
		}

		private ClassWithGenericInterface CreateClassWithGenericInterface()
		{
			return new ClassWithGenericInterface(
				this.mockGenericInterfaceBool.Object,
				this.mockGenericInterfaceListString.Object,
				this.mockSomeInterface.Object)
			{
				Interface2 = this.mockInterface3.Object,
				GenericInterface3 = this.mockGenericInterfaceListInt.Object,
				GenericInterface4 = this.mockGenericInterfaceListSomeOtherInterface.Object,
			};
		}

		[Fact]
		public void TestMethod1()
		{
			// Arrange
			var unitUnderTest = this.CreateClassWithGenericInterface();

			// Act

			// Assert
			Assert.True(false);
		}
	}
}
