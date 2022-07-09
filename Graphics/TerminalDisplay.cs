using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class TerminalDisplay : ITerminalDisplay {
    public ITerminalGraphic Parent { get; set; }
    private List<ITerminalGraphic> children = new List<ITerminalGraphic>();

    public virtual string GetTerminalGraphic() {
        StringBuilder builder = new StringBuilder(String.Empty);
        children.ForEach(graphic => builder.Append(graphic.GetTerminalGraphic()));
        return builder.ToString();
    }

    public void Clear() {
        children.Clear();
    }

    public abstract void Display();
    public void AddGraphic(ITerminalGraphic graphic) {
        children.Add(graphic);
        graphic.Parent = this;
    }

    public void RemoveGraphic(ITerminalGraphic graphic) {
        if (graphic.Parent == this) {
            children.Remove(graphic);
            graphic.Parent = null;
        } else if (children.Contains(graphic)) {
            children.Remove(graphic); 
        }
    }

    public void ReplaceGraphic(ITerminalGraphic oldGraphic, ITerminalGraphic newGraphic) {
        if (oldGraphic != null) {
            RemoveGraphic(oldGraphic);
        }
        AddGraphic(newGraphic);
    }

    public IEnumerable<ITerminalGraphic> GetGraphics() {
        return children;
    }

    public int GetGraphicCount() {
        return children.Count;
    }
}