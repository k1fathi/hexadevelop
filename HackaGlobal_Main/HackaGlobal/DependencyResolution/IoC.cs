// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IoC.cs" company="Web Advanced">
// Copyright 2012 Web Advanced (www.webadvanced.com)
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0

// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


using HackaGlobal.Models;
using HackaGlobal.Models.Interfaces;
using HackaGlobal.Models.Repositories;
using StructureMap.Graph;
using StructureMap.Web;

namespace HackaGlobal.DependencyResolution {
    using StructureMap;


    public static class IoC
    {
        public static IContainer Initialize()
        {
            ObjectFactory.Initialize(x =>
            {
                x.Scan(scan =>
                {
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
                    scan.With(new ControllerConvention());
                });

                x.For<IUnitOfWork>().HttpContextScoped().Use<MyDbContext>();
                x.For<ICitiesRepository>().Use<CitiesRepository>();
                x.For<ICityOrganizersRepository>().Use<CityOrganizersRepository>();
                x.For<ICitySponsorsRepository>().Use<CitySponsorsRepository>();
                x.For<IEventCommentsRepository>().Use<EventCommentsRepository>();
                x.For<IEventLikesRepository>().Use<EventLikesRepository>();
                x.For<IEventMembersRepository>().Use<EventMembersRepository>();
                x.For<IEventsRepository>().Use<EventsRepository>();
                x.For<IEventSponsorsRepository>().Use<EventSponsorsRepository>();
                x.For<IGalleryRepository>().Use<GalleryRepository>();
                x.For<INewsRepository>().Use<NewsRepository>();
                x.For<INewsCommentsRepository>().Use<NewsCommentsRepository>();
                x.For<ISettingRepository>().Use<SettingRepository>();
                x.For<ITeamsRepository>().Use<TeamsRepository>();
                x.For<ITeamUsersRepository>().Use<TeamUsersRepository>();
            });
            return ObjectFactory.Container;
        }
    }
}