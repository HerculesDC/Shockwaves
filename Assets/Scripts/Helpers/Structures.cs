using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState { START, SETUP, LEVEL_1, LEVEL_2, LEVEL_3, LEVEL_END, LEVEL_NONE, GAME_END, STATE_COUNT }

public enum Scenes { START, LEVEL_1, LEVEL_2, LEVEL_3, END_SCENE, SCENE_COUNT }

public enum CanvasState { START, SETUP, LEVEL, LEVEL_END, END, CANVAS_COUNT }

public enum ShockWaveTypes { STANDARD, GUST, EXPLOSION, SHOCKWAVE_COUNT }

public enum MaterialProperties { CONCRETE, DIRT, ICE, GLASS, METAL, PAPER, PLASTIC, RUBBER, WOOD, MAT_COUNT }

public struct MaterialProperty {

    public Material material;
    public PhysicMaterial physicMaterial;
    public Texture texture; //in the future, the idea is to have either this or material
}

struct InputHandler { }

struct Cam { }

public class Structures {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
