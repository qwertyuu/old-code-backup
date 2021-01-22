using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SelectionTest
{
    class Selection
    {
        public List<Bonhomme> actualSelection { get; set; }
        public Bonhomme[] armée { get; private set; }
        public void CtrlClick(Bonhomme clickedGuy)
        {
            armée[clickedGuy.index].selected = !clickedGuy.selected;
            if (actualSelection.Contains(clickedGuy))
            {
                actualSelection.Remove(clickedGuy);
            }
            else
            {
                actualSelection.Add(clickedGuy);
            }
        }
        public void CtrlClick(List<Bonhomme> clickedGuys)
        {
            List<Bonhomme> unSelected = clickedGuys.Where(guy => !guy.selected).ToList();
            foreach (var item in unSelected)
            {
                armée[item.index].selected = true;
                actualSelection.Add(armée[item.index]);
            }
        }
        public void NewSelection(List<Bonhomme> newSelection)
        {
            List<Bonhomme> toUnselect = actualSelection.Except(newSelection).ToList();
            foreach (var item in toUnselect)
            {
                actualSelection.Remove(item);
                armée[item.index].selected = false;
            }
            List<Bonhomme> toAdd = newSelection.Except(actualSelection).ToList();
            foreach (var item in toAdd)
            {
                armée[item.index].selected = true;
                actualSelection.Add(item);
            }
        }
        public void NewSelection(Bonhomme newSelection)
        {
            foreach (var item in actualSelection)
            {
                armée[item.index].selected = false;
            }
            actualSelection.Clear();
            armée[newSelection.index].selected = true;
            actualSelection.Add(newSelection);
        }

        public void Clear()
        {
            foreach (var item in actualSelection)
            {
                armée[item.index].selected = false;
            }
            actualSelection.Clear();
        }

        public Selection(ref Bonhomme[] _armée)
        {
            armée = _armée;
            actualSelection = new List<Bonhomme>();
        }
    }
}
