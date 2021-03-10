﻿// Copyright ©2021 Jacobs Data Solutions

// Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except in compliance with the License. You may obtain a copy of the
// License at

// http://www.apache.org/licenses/LICENSE-2.0

// Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR
// CONDITIONS OF ANY KIND, either express or implied. See the License for the specific language governing permissions and limitations under the License.
using AutoFixture;
using JDS.OrgManager.Application.Common.Mapping;
using JDS.OrgManager.Application.Common.TimeOff;
using Xunit;

namespace JDS.OrgManager.Application.UnitTests.HumanResources.PaidTimeOffPolicies
{
    public class PaidTimeOffPolicyDbEntityToDomainEntityMapperTests
    {
        private readonly Fixture fixture;

        private readonly PaidTimeOffPolicyDbEntityToDomainEntityMapper mapper;

        public PaidTimeOffPolicyDbEntityToDomainEntityMapperTests()
        {
            mapper = new PaidTimeOffPolicyDbEntityToDomainEntityMapper();

            fixture = new Fixture();
            // client has a circular reference from AutoFixture point of view
            fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        }

        [Fact]
        public void Map_WorksAsExpected()
        {
            var d = fixture.Create<PaidTimeOffPolicyEntity>();
            var e = mapper.Map(d);
            Assert.Equal(d.Id, e.Id);
            Assert.Equal(d.AllowsUnlimitedPto, e.AllowsUnlimitedPto);
            Assert.Equal(d.EmployeeLevel, e.EmployeeLevel);
            Assert.Equal(d.IsDefaultForEmployeeLevel, e.IsDefaultForEmployeeLevel);
            Assert.Equal(d.MaxPtoHours, e.MaxPtoHours);
            Assert.Equal(d.Name, e.Name);
            Assert.Equal(d.PtoAccrualRate, e.PtoAccrualRate);
        }
    }
}