using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScheduleManager : Singleton<ScheduleManager>
{
    class TaskScore
    {
        public Task task;
        public int score;
        public TaskScore(Task t, int s)
        {
            task = t;
            score = s;
        }
    }

    public Place[] allPlaces; //contains all the places in the game. 

    //gets the task based on the lowest need and the energy score of the task
    public Task GetTask(NPC npc)
    {
        Task task = new Task();
        Need lowest = npc.GetLowestNeed();
        List<Place> places = FindAllPlaces(lowest);
        List<TaskScore> scores = CalculateAllScores(places);
        TaskScore lowestScore = FindLowestScore(scores);

        return lowestScore.task;
    }

    //finds the lowest score in a given list of taskScores
    private static TaskScore FindLowestScore(List<TaskScore> scores)
    {
        TaskScore lowestScore = scores[0];
        foreach (TaskScore taskScore in scores)
            if (lowestScore.score > taskScore.score)
                lowestScore = taskScore;
        return lowestScore;
    }

    //creates taskScores for each task in each place 
    private static List<TaskScore> CalculateAllScores(List<Place> places)
    {
        List<TaskScore> taskScores = new List<TaskScore>();
        foreach (Place place in places)
            foreach (Task placeTask in place.tasks)
            {
                //incorporate location
                int score = placeTask.energyDep - placeTask.energyRes;
                TaskScore taskScore = new TaskScore(placeTask, score);
                taskScores.Add(taskScore);
            }
        return taskScores;
    }

    //finds all the places that match the given need
    List<Place> FindAllPlaces(Need need)
    {
        List<Place> places = new List<Place>();
        foreach(Place place in allPlaces)
            if (place.need == need)
                places.Add(place);
        return places;
    }
}
