using System;
using System.Collections.Generic;

public abstract class SortingAlgorithm {

  protected string name = " ";
  public string Name { get => name; }

  public delegate void OnComparisonDelegate();
  public delegate void OnArrayAccessDelegate();
  public delegate void OnModificationDelegate();
  public delegate void OnFinishDelegate();
  
  public event OnComparisonDelegate OnComparison;
  public event OnArrayAccessDelegate OnArrayAccess;
  public event OnModificationDelegate OnModification;
  public event OnFinishDelegate OnFinish;

  protected bool stopped;
  public bool Stopped { get => stopped; }

  public SortingAlgorithm() { }

  public abstract void Sort<T>(List<T> target)  where T : IComparable<T>;

  public virtual void Stop() {
    stopped = true;
  }

  protected virtual void InvokeOnComparison() {
    OnComparison?.Invoke();
  }

  protected virtual void InvokeOnArrayAccess() {
    OnArrayAccess?.Invoke();
  }

  protected virtual void InvokeOnModification() {
    OnModification?.Invoke();
  }

  protected virtual void InvokeOnFinish() {
    OnFinish?.Invoke();
  }
}