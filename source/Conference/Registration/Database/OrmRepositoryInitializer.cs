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
    using System;
    using System.Data.Entity;

    public class OrmRepositoryInitializer : IDatabaseInitializer<OrmRepository>
    {
        private IDatabaseInitializer<OrmRepository> innerInitializer;

        public OrmRepositoryInitializer(IDatabaseInitializer<OrmRepository> innerInitializer)
        {
            this.innerInitializer = innerInitializer;
        }

        public void InitializeDatabase(OrmRepository context)
        {
            this.innerInitializer.InitializeDatabase(context);

            // Create views, seed reference data, etc.

            // TODO: remove hardcoded seats availability.
            if (context.Set<ConferenceSeatsAvailability>().Find(Guid.Empty) == null)
            {
                var availability = new ConferenceSeatsAvailability(Guid.Empty);
                availability.AddSeats(50);
                context.Save(availability);
            }

            context.SaveChanges();
        }
    }
}
