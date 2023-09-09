using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EntityManager : MonoBehaviour
{
    public static EntityManager Instance;
    public Canvas healthBarCanvas;
    public List<Entity> leaders;
    public List<Team> teams;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        SetupTeams();
    }
    public void SetupTeams()
    {
        teams = new List<Team>();

        //create a team for all leaders
        for (int i = 0; i < leaders.Count; i++)
        {
            teams.Add(leaders[i].team);
        }
    }
    public void SpawnEntity(Entity entity, Vector2 position)
    {
        Entity newEntity = Instantiate(entity, position, Quaternion.identity);
        leaders.Add(newEntity);
        teams.Add(newEntity.team);
    }
    public void DestroyEntity(Entity entity)
    {
        entity.healthBar.DestroyHealthBar();
        teams.Remove(entity.team);
        leaders.Remove(entity);
    }
    public Entity GetTarget(Entity attacker, TargetingType type, bool canTargetSelf)
    {
        List<Team> targetTeams;
        if (canTargetSelf)
        {
            targetTeams = teams;
        }
        else
        {
            targetTeams = GetEnemyTeams(attacker);
        }
        if (targetTeams == null || targetTeams.Count == 0)
        {
            Messenger.Instance.Log("Can't get target: List of valid teams is empty.");
            return null;
        }
        switch (type)
        {
            case TargetingType.Random:
                return GetRandomEntity(GetEntitiesOfTeams(targetTeams));
            case TargetingType.RandomLeader:
                return GetRandomEntity(GetLeadersOfTeams(targetTeams));
            case TargetingType.HighestHealth:
                return GetHighestHealthEntity(GetEntitiesOfTeams(targetTeams));
            case TargetingType.LowestHealth:
                return GetLowestHealthEntity(GetEntitiesOfTeams(targetTeams));
        }
        return null;
    }
    public bool OneLeaderLeft()
    {
        return GetLeadersOfTeams(teams).Where(x => x.health.isAlive == true).ToList().Count == 1;
    }
    public void EnableAllEntities()
    {
        GetEntitiesOfTeams(teams).ForEach(entity => entity.EnableEntity());
    }
    public void DisableAllEntities()
    {
        GetEntitiesOfTeams(teams).ForEach(entity => entity.DisableEntity());
    }
    #region helpers

    private Entity GetRandomEnemy(Entity attacker)
    {
        return GetRandomEntity(GetRandomTeam(GetEnemyTeams(attacker)));
    }

    private Team GetEntityTeam(Entity entity)
    {
        foreach (Team team in teams)
        {
            if (team.GetAllEntities().Contains(entity))
            {
                return team;
            }
        }
        return null;
    }
    private List<Team> GetEnemyTeams(Entity attacker)
    {
        List<Team> enemyTeams = teams.Where(team => team != attacker.team).ToList();
        if (enemyTeams.Count == 0)
        {
            Messenger.Instance.Log("No more enemy teams");
        }
        return enemyTeams;
    }
    private Team GetRandomTeam(List<Team> teamList)
    {
        if (teamList.Count == 0)
        {
            Messenger.Instance.Log("Team list empty");
            return null;
        }
        return teamList[Random.Range(0, teamList.Count)];
    }
    private List<Entity> GetEntitiesOfTeams(List<Team> teams)
    {
        List<Entity> combinedList = new List<Entity>();
        teams.ForEach(x => combinedList.AddRange(x.GetAllEntities()));
        return combinedList;
    }

    private List<Entity> GetLeadersOfTeams(List<Team> teams)
    {
        List<Entity> combinedList = new List<Entity>();
        teams.ForEach(x => combinedList.Add(x.parentEntity));
        return combinedList;
    }
    private Entity GetRandomEntity(Team team)
    {
        List<Entity> entities = team.GetAllEntities();
        return entities[Random.Range(0, entities.Count)];
    }
    private Entity GetRandomEntity(List<Entity> entities)
    {
        if (entities == null || entities.Count == 0)
        {
            Messenger.Instance.Log("Can't get random entity: List of entities is empty.");
            return null;
        }
        return entities[Random.Range(0, entities.Count)];
    }
    private Entity GetLowestHealthEntity(List<Entity> entities)
    {
        if (entities == null || entities.Count == 0)
        {
            Messenger.Instance.Log("Can't get highest health entity: List of entities is empty.");
            return null;
        }
        return entities.OrderBy(a => a.health.health).First(); ;
    }

    private Entity GetHighestHealthEntity(List<Entity> entities)
    {
        if (entities == null || entities.Count == 0)
        {
            Messenger.Instance.Log("Can't get lowest health entity: List of entities is empty.");
            return null;
        }
        return entities.OrderByDescending(a => a.health.health).First(); ;
    }
    #endregion
}
