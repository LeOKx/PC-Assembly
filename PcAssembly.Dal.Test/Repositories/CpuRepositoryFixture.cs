using Microsoft.EntityFrameworkCore;
using Moq;
using PcAssembly.Dal.Repositories;
using PcAssembly.Dal.Test.MockDbSet;
using PcAssembly.Domain;
using PcAssembly.Domain.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace PcAssembly.Dal.Test.Repositories
{
    public class CpuRepositoryFixture : IDisposable
    {
        private bool _disposed = false;
        private CpuRepository _repo;
        private Mock<DataContext> mockContext;
        //private Mock<CPU> cpusMock;
        //private Mock<CpuRepository> mockRepo;

        public CpuRepositoryFixture()
        {
            var options = new DbContextOptions<DataContext>();
            this.mockContext = new Mock<DataContext>(options);
            //var context = new DataContext(options);
            //this.mockRepo = new Mock<CpuRepository>();

            this._repo = new CpuRepository(new DataContext(options));
        }

        private async Task<List<CPU>> GetTestCPUs()
        {
            return await Task.FromResult(new List<CPU>
            {
                new CPU()
                {
                    Model = "Intel Core i7-8700K",
                    Company = Domain.Enums.Company.Intel,
                    Type = Domain.Enums.TypeComponent.CPU,
                    Price = 10000,
                    PowerConsumption = 180,
                    Socket = Domain.Enums.Socket.Socket_1151,
                    Family = Domain.Enums.CpuFamily.Core_i7,
                    Generation = Domain.Enums.CpuGeneration.CoffeLake,
                    Cores = 6,
                    Threads = 12,
                    Frequency = 4.7f,
                },
                new CPU()
                {
                    Model = "Intel Core i7-10700K",
                    Company = Domain.Enums.Company.Intel,
                    Type = Domain.Enums.TypeComponent.CPU,
                    Price = 11000,
                    PowerConsumption = 200,
                    Socket = Domain.Enums.Socket.Socket_1151_V2,
                    Family = Domain.Enums.CpuFamily.Core_i7,
                    Generation = Domain.Enums.CpuGeneration.CoffeLakeRefresh,
                    Cores = 8,
                    Threads = 8,
                    Frequency = 4.9f
                }
            });
        }

        [Fact]
        public async Task ExistComponentWithTheModel_Found()
        {
            string model = "Intel Core i7-8700K";

            //List<CPU> cpus = new List<CPU>()
            //{
            //    new CPU()
            //    {
            //        Model = "Intel Core i7-8700K",
            //        Company = Domain.Enums.Company.Intel,
            //        Type = Domain.Enums.TypeComponent.CPU,
            //        Price = 10000,
            //        PowerConsumption = 180,
            //        Socket = Domain.Enums.Socket.Socket_1151,
            //        Family = Domain.Enums.CpuFamily.Core_i7,
            //        Generation = Domain.Enums.CpuGeneration.CoffeLake,
            //        Cores = 6,
            //        Threads = 12,
            //        Frequency = 4.7f,
            //    },
            //    new CPU()
            //    {
            //        Model = "Intel Core i7-10700K",
            //        Company = Domain.Enums.Company.Intel,
            //        Type = Domain.Enums.TypeComponent.CPU,
            //        Price = 11000,
            //        PowerConsumption = 200,
            //        Socket = Domain.Enums.Socket.Socket_1151_V2,
            //        Family = Domain.Enums.CpuFamily.Core_i7,
            //        Generation = Domain.Enums.CpuGeneration.CoffeLakeRefresh,
            //        Cores = 8,
            //        Threads = 8,
            //        Frequency = 4.9f
            //    }

            //};
            //var cpus = await GetTestCPUs();
            //var mock = cpus.AsDbSetMock();
            //this.mockContext.Setup(cpu => cpu.CPUs).Returns(mock.Object).Verifiable();
            //this.mockRepo.Setup(repo => repo.GetAll()).Returns(GetTestCPUs());

            var result = await this._repo.ExistComponentWithTheModel(model);

            Assert.True(result);

            model = "NoCPU";
            result = await this._repo.ExistComponentWithTheModel(model);
            Assert.False(result);
        }

        [Fact]
        public async Task ExistComponentWithTheModel_NotFound()
        {
            string model = "Intel Core i7-10700K";
            //List<CPU> cpus = new List<CPU>()
            //{
            //    new CPU()
            //    {
            //        Model = "Intel Core i7-10700K",
            //        Company = Domain.Enums.Company.Intel,
            //        Type = Domain.Enums.TypeComponent.CPU,
            //        Price = 11000,
            //        PowerConsumption = 200,
            //        Socket = Domain.Enums.Socket.Socket_1151_V2,
            //        Family = Domain.Enums.CpuFamily.Core_i7,
            //        Generation = Domain.Enums.CpuGeneration.CoffeLakeRefresh,
            //        Cores = 8,
            //        Threads = 8,
            //        Frequency = 4.9f
            //    }
            //};

            //var mock = cpus.AsDbSetMock();
            //this.mockContext.Setup(cpu => cpu.CPUs).Returns(mock.Object).Verifiable();

            var result = await this._repo.ExistComponentWithTheModel(model);
            Assert.False(result);
        }
















        ~CpuRepositoryFixture()
        {
            this.Dispose(false);
        }

        public void Dispose()
         {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
        private void Dispose(bool disposing)
        {
            if (this._disposed)
            {
                return;
            }

            this._disposed = true;
        }
    }
}
