﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace svc
{



	public class SvcPhysicsCfg : SvcDatabaseCfg
	{
	}

	public partial class SvcPhysics : SvcDatabase<SvcPhysicsCfg>
	{
		// TODO DUPE code refactor to somewhere shared.
		/*
		public enum State
		{
			Invalid,
			Early,
			StartingUp,
			Running,
			ShuttingDown,
		}
		*/

		public SvcPhysics( res.Ref<SvcPhysicsCfg> _cfg )
			:
			base( _cfg )
		{
		}

		override internal void handle( msg.Startup startup )
		{
			base.handle( startup );

			var timed = db.Act.create( timedTick );
			m_sys.future( timed, 60.0, 0.0 );
		}

		DateTime m_lastTick = DateTime.Now;

		void timedTick()
		{
			var ts = DateTime.Now - m_lastTick;
			m_lastTick = DateTime.Now;

			lib.Log.debug( $"{Thread.CurrentThread.Name} Physics Timed Tick! {ts.TotalMilliseconds}" );
			var act = db.Act.create( timedTick );
			m_sys.future( act, 60.0, 0.0 );
		}

		internal override void frameTick()
		{
			base.frameTick();
		}



		// @@@@ Test for passing in FormattableString s.
		void show( FormattableString format )
		{

		}

		//public static ImmutableDictionary<EntityId, Entity> m_snapshot = ImmutableDictionary<EntityId, Entity>.Empty;

	}


}
