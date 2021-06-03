using System.Collections.Generic;
using UnityEngine.Events;

public enum eSubjectID
{ 
    TestEvent_1,
    TestEvent_2,
    TestEvent_3,
}

public class ObserverManager : Singleton<ObserverManager>
{
    #region Subject Class
    public class Subject<TValue1> : UnityEvent<TValue1>{}

    public class Subject<TValue1, TValue2> : UnityEvent<TValue1, TValue2>{}

    public class Subject<TValue1, TValue2, TValue3> : UnityEvent<TValue1, TValue2, TValue3>{}
    #endregion

    Dictionary<eSubjectID, UnityEventBase> dicSubjects = new Dictionary<eSubjectID, UnityEventBase>();

    #region Get Subject
    Subject<TValue1> GetSubject<TValue1>(eSubjectID _id)
    {
        Subject<TValue1> _targetSubject = null;
        if (dicSubjects.ContainsKey(_id) == false)
        {
            _targetSubject = new Subject<TValue1>();
            dicSubjects.Add(_id, new Subject<TValue1>());
        }
        else
            _targetSubject = (Subject<TValue1>)dicSubjects[_id];

        return _targetSubject;
    }

    Subject<TValue1, TValue2> GetSubject<TValue1, TValue2>(eSubjectID _id)
    {
        Subject<TValue1, TValue2> _targetSubject = null;
        if (dicSubjects.ContainsKey(_id) == false)
        {
            _targetSubject = new Subject<TValue1, TValue2>();
            dicSubjects.Add(_id, new Subject<TValue1, TValue2>());
        }
        else
            _targetSubject = (Subject<TValue1, TValue2>)dicSubjects[_id];

        return _targetSubject;
    }
    Subject<TValue1, TValue2, TValue3> GetSubject<TValue1, TValue2, TValue3>(eSubjectID _id)
    {
        Subject<TValue1, TValue2, TValue3> _targetSubject = null;
        if (dicSubjects.ContainsKey(_id) == false)
        {
            _targetSubject = new Subject<TValue1, TValue2, TValue3>();
            dicSubjects.Add(_id, new Subject<TValue1, TValue2, TValue3>());
        }
        else
            _targetSubject = (Subject<TValue1, TValue2, TValue3>)dicSubjects[_id];

        return _targetSubject;
    }
    #endregion

    #region Regist Observer
    public void Regist<TValue1>(eSubjectID _id, UnityAction<TValue1> _observe)
    {
        Subject<TValue1> _subject = GetSubject<TValue1>(_id);
        if (_subject == null)
        {
            UnityEngine.Debug.LogErrorFormat("ObserveManager Error : This method does not match to SubjectID. SubjectID = {0}", _id);
            return;
        }
        _subject.AddListener(_observe);
    }
    public void Regist<TValue1, TValue2>(eSubjectID _id, UnityAction<TValue1, TValue2> _observe)
    {
        Subject<TValue1, TValue2> _subject = GetSubject<TValue1, TValue2>(_id);
        if (_subject == null)
        {
            UnityEngine.Debug.LogErrorFormat("ObserveManager Error : This method does not match to SubjectID. SubjectID = {0}", _id);
            return;
        }
        _subject.AddListener(_observe);
    }
    public void Regist<TValue1, TValue2, TValue3>(eSubjectID _id, UnityAction<TValue1, TValue2, TValue3> _observe)
    {
        Subject<TValue1, TValue2, TValue3> _subject = GetSubject<TValue1, TValue2, TValue3>(_id);
        if (_subject == null)
        {
            UnityEngine.Debug.LogErrorFormat("ObserveManager Error : This method does not match to SubjectID. SubjectID = {0}", _id);
            return;
        }
        _subject.AddListener(_observe);
    }
    #endregion

    #region Unregist Observer
    public void Unregist<TValue1>(eSubjectID _id, UnityAction<TValue1> _observe)
    {
        Subject<TValue1> _subject = GetSubject<TValue1>(_id);
        if (_subject == null)
        {
            UnityEngine.Debug.LogErrorFormat("ObserveManager Error : This method does not match to SubjectID. SubjectID = {0}", _id);
            return;
        }
        _subject.RemoveListener(_observe);
    }
    public void Unregist<TValue1, TValue2>(eSubjectID _id, UnityAction<TValue1, TValue2> _observe)
    {
        Subject<TValue1, TValue2> _subject = GetSubject<TValue1, TValue2>(_id);
        if (_subject == null)
        {
            UnityEngine.Debug.LogErrorFormat("ObserveManager Error : This method does not match to SubjectID. SubjectID = {0}", _id);
            return;
        }
        _subject.RemoveListener(_observe);
    }
    public void Unregist<TValue1, TValue2, TValue3>(eSubjectID _id, UnityAction<TValue1, TValue2, TValue3> _observe)
    {
        Subject<TValue1, TValue2, TValue3> _subject = GetSubject<TValue1, TValue2, TValue3>(_id);
        if (_subject == null)
        {
            UnityEngine.Debug.LogErrorFormat("ObserveManager Error : This method does not match to SubjectID. SubjectID = {0}", _id);
            return;
        }
        _subject.RemoveListener(_observe);
    }
    #endregion

    #region Event Notify
    public void Notify<TValue1>(eSubjectID _id, TValue1 _value)
    {
        Subject<TValue1> _subject = GetSubject<TValue1>(_id);
        if (_subject == null)
        {
            UnityEngine.Debug.LogErrorFormat("ObserveManager Error : This method does not match to SubjectID. SubjectID = {0}", _id);
            return;
        }
        _subject.Invoke(_value);
    }
    public void Notify<TValue1, TValue2>(eSubjectID _id, TValue1 _value, TValue2 _value2)
    {
        Subject<TValue1, TValue2> _subject = GetSubject<TValue1, TValue2>(_id);
        if (_subject == null)
        {
            UnityEngine.Debug.LogErrorFormat("ObserveManager Error : This method does not match to SubjectID. SubjectID = {0}", _id);
            return;
        }
        _subject.Invoke(_value, _value2);
    }
    public void Notify<TValue1, TValue2, TValue3>(eSubjectID _id, TValue1 _value, TValue2 _value2, TValue3 _value3)
    {
        Subject<TValue1, TValue2, TValue3> _subject = GetSubject<TValue1, TValue2, TValue3>(_id);
        if (_subject == null)
        {
            UnityEngine.Debug.LogErrorFormat("ObserveManager Error : This method does not match to SubjectID. SubjectID = {0}", _id);
            return;
        }
        _subject.Invoke(_value, _value2, _value3);
    }
    #endregion

    public void ClearObserver(eSubjectID _id)
    {
        if (dicSubjects.ContainsKey(_id))
            dicSubjects[_id].RemoveAllListeners();
    }
}

public class Singleton<TType> where TType : new()
{
    private static TType mInstance;
    public static TType instance 
    { 
        get 
        {
            if (mInstance == null)
                mInstance = new TType();
            return mInstance;
        }
    }
}