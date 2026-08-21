using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class HanoiSolver : MonoBehaviour
{
    public Game game;

    public Tower source;
    public Tower auxilary;
    public Tower target;

    public int discCount;
    public float secondsBetweenMoves = 0.5f;

    [ContextMenu("Auto Solve")]
    public void Solve()
	{
        discCount = source.rings.Count;
        StartCoroutine(SolveRoutine());
	}

    private IEnumerator SolveRoutine()
	{
        var moves = new List<(Tower from, Tower to)>();
        BuildMoves(discCount, source, target, auxilary, moves);

		foreach (var (from,to) in moves)
		{
            game.MoveRing(from, to);
            yield return new WaitForSeconds(secondsBetweenMoves);
		}
	}

    public static void BuildMoves(int count, Tower from, Tower to, Tower via, List<(Tower,Tower)> moves)
	{
        if (count <= 0) return;

        BuildMoves(count - 1, from, via, to, moves);
        moves.Add((from, to));
        BuildMoves(count - 1, via, to, from, moves);
	}
}
