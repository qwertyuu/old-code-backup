class Voiture:
    def __init__(self, m, a, g, c):
        self.Modele = m
        self.Annee = a
        self.Genre = g
        self.Couleur = c

    def rentrerDans(self, char):
        print "Oups, j'ai rentrer dans le " + char.Modele


Chevrolet = Voiture("Chevrolet", 1999, "Pick up", "Brun")
