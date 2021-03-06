﻿// ==============================================================================================================
// Microsoft patterns & practices
// CQRS Journey project
// ==============================================================================================================
// Copyright (c) Microsoft Corporation and contributors http://cqrsjourney.github.com/contributors/members
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except in compliance 
// with the License. You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software distributed under the License is 
// distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. 
// See the License for the specific language governing permissions and limitations under the License.
// ==============================================================================================================

namespace Registration.Database
{
    using System.Data.Entity;

    public class OrmSagaRepositoryInitializer : IDatabaseInitializer<OrmSagaRepository>
    {
        private IDatabaseInitializer<OrmSagaRepository> innerInitializer;

        public OrmSagaRepositoryInitializer(IDatabaseInitializer<OrmSagaRepository> innerInitializer)
        {
            this.innerInitializer = innerInitializer;
        }

        public void InitializeDatabase(OrmSagaRepository context)
        {
            this.innerInitializer.InitializeDatabase(context);

            // Create views, seed reference data, etc.

            context.SaveChanges();
        }
    }
}
