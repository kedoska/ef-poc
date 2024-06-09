public class AgentRepository : Repository<Agent>
{
    public AgentRepository(AppDbContext context) : base(context)
    {
    }

    // Add any additional methods specific to Agent here
}