using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace MonoSnake
{
	public class SnakeView : View
	{
		const string TAG = "SnakeView";

		/**
		 * Current mode of application: READY to run, RUNNING, or you have already
		 * lost. static final ints are used instead of an enum for performance
		 * reasons.
		 */
		int mMode = READY;
		public const int PAUSE = 0;
		public const int READY = 1;
		public const int RUNNING = 2;
		public const int LOSE = 3;
			
	    /**
	     * Current direction the snake is headed.
	     */
	    int mDirection = NORTH;
	    int mNextDirection = NORTH;
	    const int NORTH = 1;
	    const int SOUTH = 2;
	    const int EAST = 3;
	    const int WEST = 4;
			
		
	    /**
	     * Labels for the drawables that will be loaded into the TileView class
	     */
	    const int RED_STAR = 1;
	    const int YELLOW_STAR = 2;
	    const int GREEN_STAR = 3;
	
	    /**
	     * mScore: used to track the number of apples captured mMoveDelay: number of
	     * milliseconds between snake movements. This will decrease as apples are
	     * captured.
	     */
	    long mScore = 0;
	    long mMoveDelay = 600;
	    
		/**
	     * mLastMove: tracks the absolute time when the snake last moved, and is used
	     * to determine if a move should be made based on mMoveDelay.
	     */
	    long mLastMove;
		
		TextView statusText;
	    
		
		
		public SnakeView (Context context,IAttributeSet attrs) :
			base (context, attrs)
		{
			Initialize ();
		}

		public SnakeView (Context context,IAttributeSet attrs, int defStyle) :
			base (context, attrs, defStyle)
		{
			Initialize ();
		}

		private void Initialize ()
		{
		}
	}
}