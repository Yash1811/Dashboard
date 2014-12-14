using System.Collections.Generic;

namespace LocalAccountsApp.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using LocalAccountsApp.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<LocalAccountsApp.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "LocalAccountsApp.Models.ApplicationDbContext";
        }

        protected override void Seed(LocalAccountsApp.Models.ApplicationDbContext context)
        {
            if (context.Ec2Instances.Any())
            {
                return;
            }

            context.Ec2Instances.AddRange(CreateEc2Instance());
            context.SaveChanges();
        }

        private static IEnumerable<ElasticCloudViewModel> CreateEc2Instance()
        {
            var ec2Instances = new List<ElasticCloudViewModel> 
            {
                new ElasticCloudViewModel
                { 
                    Id = " ap-northeast-1",
                    Name = "Asia Pacific (Tokyo)",
                    Type ="t2.micro",
                    State="pending",
                    AvailableZone = "ap-northeast-1b",
                    PrivateIp = "10.20.30.40",
                    PublicIp = "54.210.167.204",
                    IsActive = true
                },
                new ElasticCloudViewModel
                { 
                    Id = "ap-southeast-1",
                    Name = "Asia Pacific (Singapore)",
                    Type ="t2.small",
                    State="running",
                    AvailableZone = "ap-southeast-1a",
                    PrivateIp = "10.30.40.50",
                    PublicIp = "64.210.167.204",
                    IsActive = false
                },
                new ElasticCloudViewModel
                { 
                    Id = "ap-southeast-2",
                    Name = "Asia Pacific (Sydney)",
                    Type ="t2.medium",
                    State="stopped",
                    AvailableZone = "ap-southeast-2c",
                    PrivateIp = "10.40.50.60",
                    PublicIp = "64.210.167.204",
                    IsActive = true
                },
                new ElasticCloudViewModel
                { 
                    Id = "eu-central-1",
                    Name = "EU (Frankfurt)",
                    Type ="t3.micro",
                    State="rebooted",
                    AvailableZone = "eu-central-1a",
                    PrivateIp = "10.50.60.70",
                    PublicIp = "74.210.167.104",
                    IsActive = false
                },
                new ElasticCloudViewModel
                { 
                    Id = "eu-west-1",
                    Name = "EU (Ireland)",
                    Type ="t3.medium",
                    State="pending",
                    AvailableZone = "eu-west-1a",
                    PrivateIp = "10.60.70.80",
                    PublicIp = "84.210.167.104",
                    IsActive = true
                }
                ,
                new ElasticCloudViewModel
                { 
                    Id = "sa-east-1",
                    Name = "South America (Sao Paulo)",
                    Type ="t3.medium",
                    State="pending",
                    AvailableZone = "sa-east-1a",
                    PrivateIp = "10.60.70.80",
                    PublicIp = "84.210.167.104",
                    IsActive = false
                },
                new ElasticCloudViewModel
                { 
                    Id = "us-east-1",
                    Name = "US East (N. Virginia)",
                    Type ="t3.medium",
                    State="pending",
                    AvailableZone = "us-east-1b",
                    PrivateIp = "10.60.70.80",
                    PublicIp = "84.210.167.104",
                    IsActive = true
                }
                ,
                new ElasticCloudViewModel
                { 
                    Id = "us-west-1",
                    Name = "US West (N. California)",
                    Type ="t3.medium",
                    State="pending",
                    AvailableZone = "us-west-1a",
                    PrivateIp = "10.60.70.80",
                    PublicIp = "84.210.167.104",
                    IsActive = false
                }
                ,
                new ElasticCloudViewModel
                { 
                    Id = "us-west-2",
                    Name = "US West (Oregon)",
                    Type ="t3.medium",
                    State="pending",
                    AvailableZone = "us-west-2c",
                    PrivateIp = "10.60.70.80",
                    PublicIp = "84.210.167.104",
                    IsActive = true
                }
                ,
                new ElasticCloudViewModel
                { 
                    Id = "us-south-3",
                    Name = "US South (Texas)",
                    Type ="t3.large",
                    State="pending",
                    AvailableZone = "us-south-3c",
                    PrivateIp = "10.60.70.80",
                    PublicIp = "94.210.167.104",
                    IsActive = false
                }//kkk
                ,new ElasticCloudViewModel
                { 
                    Id = "ap-northeast-3",
                    Name = "Asia Pacific (Tokyo)",
                    Type ="t2.micro",
                    State="pending",
                    AvailableZone = "ap-northeast-3b",
                    PrivateIp = "10.20.30.40",
                    PublicIp = "54.210.167.204",
                    IsActive = true
                },
                new ElasticCloudViewModel
                { 
                    Id = "ap-southeast-3",
                    Name = "Asia Pacific (Singapore)",
                    Type ="t2.small",
                    State="running",
                    AvailableZone = "ap-southeast-3a",
                    PrivateIp = "10.30.40.50",
                    PublicIp = "64.210.167.204",
                    IsActive = false
                },
                new ElasticCloudViewModel
                { 
                    Id = "ap-southeast-4",
                    Name = "Asia Pacific (Sydney)",
                    Type ="t2.medium",
                    State="stopped",
                    AvailableZone = "ap-southeast-4c",
                    PrivateIp = "10.40.50.60",
                    PublicIp = "64.210.167.204",
                    IsActive = true
                },
                new ElasticCloudViewModel
                { 
                    Id = "eu-central-3",
                    Name = "EU (Frankfurt)",
                    Type ="t3.micro",
                    State="rebooted",
                    AvailableZone = "eu-central-3a",
                    PrivateIp = "10.50.60.70",
                    PublicIp = "74.210.167.104",
                    IsActive = false
                },
                new ElasticCloudViewModel
                { 
                    Id = "eu-west-3",
                    Name = "EU (Ireland)",
                    Type ="t3.medium",
                    State="pending",
                    AvailableZone = "eu-west-3a",
                    PrivateIp = "10.60.70.80",
                    PublicIp = "84.210.167.104",
                    IsActive = true
                }
                ,
                new ElasticCloudViewModel
                { 
                    Id = "sa-east-3",
                    Name = "South America (Sao Paulo)",
                    Type ="t3.medium",
                    State="pending",
                    AvailableZone = "sa-east-3a",
                    PrivateIp = "10.60.70.80",
                    PublicIp = "84.210.167.104",
                    IsActive = false
                },
                new ElasticCloudViewModel
                { 
                    Id = "us-east-3",
                    Name = "US East (N. Virginia)",
                    Type ="t3.medium",
                    State="pending",
                    AvailableZone = "us-east-3b",
                    PrivateIp = "10.60.70.80",
                    PublicIp = "84.210.167.104",
                    IsActive = true
                }
                ,
                new ElasticCloudViewModel
                { 
                    Id = "us-west-12",
                    Name = "US West (N. California)",
                    Type ="t3.medium",
                    State="pending",
                    AvailableZone = "us-west-12a",
                    PrivateIp = "10.60.70.80",
                    PublicIp = "84.210.167.104",
                    IsActive = false
                }
                ,
                new ElasticCloudViewModel
                { 
                    Id = "us-west-31",
                    Name = "US West (Oregon)",
                    Type ="t3.medium",
                    State="pending",
                    AvailableZone = "us-west-31c",
                    PrivateIp = "10.60.70.80",
                    PublicIp = "84.210.167.104",
                    IsActive = true
                }
                ,
                new ElasticCloudViewModel
                { 
                    Id = "us-south-2",
                    Name = "US South (Texas)",
                    Type ="t3.large",
                    State="pending",
                    AvailableZone = "us-south-2c",
                    PrivateIp = "10.60.70.80",
                    PublicIp = "94.210.167.104",
                    IsActive = false
                }
                
            };

            return ec2Instances;
        }
    }
}
