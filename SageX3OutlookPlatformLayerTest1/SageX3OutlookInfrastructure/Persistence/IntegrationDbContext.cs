using Microsoft.EntityFrameworkCore;
using SageX3OutlookDomain.Entities;

namespace SageX3OutlookInfrastructure.Persistence;

public class IntegrationDbContext : DbContext
{
    public IntegrationDbContext(DbContextOptions<IntegrationDbContext> options) : base(options) { }

    public DbSet<Lead> Leads => Set<Lead>();
    public DbSet<TaskItem> Tasks => Set<TaskItem>();
    public DbSet<Contact> Contacts => Set<Contact>();
    public DbSet<Knowledge> Knowledges => Set<Knowledge>();

    // FIXED: Changed from 'object' to 'DbSet<ActivityLog>'
    public DbSet<ActivityLog> AuditLogs => Set<ActivityLog>();
}
