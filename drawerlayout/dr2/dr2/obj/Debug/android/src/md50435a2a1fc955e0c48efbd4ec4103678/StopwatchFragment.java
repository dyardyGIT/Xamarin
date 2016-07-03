package md50435a2a1fc955e0c48efbd4ec4103678;


public class StopwatchFragment
	extends android.app.Fragment
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("dr2.StopwatchFragment, dr2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", StopwatchFragment.class, __md_methods);
	}


	public StopwatchFragment () throws java.lang.Throwable
	{
		super ();
		if (getClass () == StopwatchFragment.class)
			mono.android.TypeManager.Activate ("dr2.StopwatchFragment, dr2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
