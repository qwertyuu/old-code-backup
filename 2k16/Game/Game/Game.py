"""
Liam Keenans Hacked Up Fighter Game!
"""

import os
import time
from random import randint
def cast(spell):
    pa = 0
    ba = 0
    if spell == "1":
        pa = randint(1, 15)
    elif spell == "2":
        pa = randint(1, 19)
    elif spell == "3":
        pa = randing(1, 20)
    else:
        print "You cannot do that!"
        return
    boss_health -= pa
    print("You Hit For :", str(pa))
    print("Boss Health :", str(boss_health))
os.system("title Game")
os.system("color 0a")
time.sleep(3)
dev_mode = ("0")
if dev_mode == "1":player_health = 1000
game_over = 0
player_health = 150
boss_health = 150
while game_over == 0:
          pa = 0
          ba = 0
          os.system("cls")
          print("\nPlayer Health = ",str(player_health))
          print("Boss Health = ",str(boss_health), '\n')
          print("Spells : 1)Frostbolt 2)Heroic Strike 3)Frozen Orb\n")
          spell = input("Cast : \n")
          cast(spell)
          print
          time.sleep(2)
          ba = randint(1,13)
          player_health -= ba
          print("You Were Hit For :",str(pa))
          print("Player Health ",str(player_health))
          time.sleep(3)
          os.system("cls")
          if player_health <= 1:
                    game_over = 1
                    print("You Lose !")
                    time.sleep(5)
          if boss_health <= 1:
                    game_over = 1
                    print("You Win!")
                    time.sleep(5)