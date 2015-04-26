﻿using UnityEngine;
using System.Collections.Generic;


public class PlayerScript : MonoBehaviour {
	public float playerSpeed = 2.0f;
	private float currentSpeed = 0.0f;

	public List<KeyCode> upButton;
	public List<KeyCode> downButton;
	public List<KeyCode> leftButton;
	public List<KeyCode> rightButton;

	private Vector3 lastMovement = new Vector3();

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// Поворот героя к мышке
		Rotation();
		// Перемещение героя
		Movement();
	
	}

	// Поворот героя к мышке
	void Rotation() {
		// Показываем игроку, где мышка
		Vector3 worldPos = Input.mousePosition;
		worldPos = Camera.main.ScreenToWorldPoint(worldPos);
		// Сохраняем координаты указателя мыши
		float dx = this.transform.position.x - worldPos.x;
		float dy = this.transform.position.y - worldPos.y;
		// Вычисляем угол между объектами «Корабль» и «Указатель»
		float angle = Mathf.Atan2(dy, dx) * Mathf.Rad2Deg;
		// Трансформируем угол в вектор
		Quaternion rot = Quaternion.Euler(new Vector3(0, 0, angle + 90));
		// Изменяем поворот героя
		this.transform.rotation = rot;
	}

		// Движение героя к мышке
	void Movement() {
		// Необходимое движение
		Vector3 movement = new Vector3();
		// Проверка нажатых клавиш
		movement += MoveIfPressed(upButton, Vector3.up);
		movement += MoveIfPressed(downButton, Vector3.down);
		movement += MoveIfPressed(leftButton, Vector3.left);
		movement += MoveIfPressed(rightButton, Vector3.right);
		// Если нажато несколько кнопок, обрабатываем это
		movement.Normalize();
		// Проверка нажатия кнопки
		if(movement.magnitude > 0)
		{
			// После нажатия двигаемся в этом направлении
			currentSpeed = playerSpeed;
			this.transform.Translate(movement * Time.deltaTime * playerSpeed, Space.World);
			lastMovement = movement;
		}
		else
		{
			// Если ничего не нажато
			this.transform.Translate(lastMovement * Time.deltaTime * currentSpeed, Space.World);
			// Замедление со временем
			currentSpeed *= 0.9f;
		}
	}
	
	// Возвращает движение, если нажата кнопка
	Vector3 MoveIfPressed(List<KeyCode> keyList, Vector3 Movement) {
		// Проверяем кнопки из списка
		foreach (KeyCode element in keyList)
		{
			if(Input.GetKey (element))
			{
				// Если нажато, покидаем функцию
				return Movement;
			}
		}
		// Если кнопки не нажаты, то не двигаемся
		return Vector3.zero;
	}

}
