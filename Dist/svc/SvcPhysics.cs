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

namespace svc
{

	public class SvcPhysicsCfg : ServiceCfg
	{
	}

	public class SvcPhysics : ServiceWithConfig<SvcPhysicsCfg>, svc.ISourceRun
	{


		public SvcPhysics( res.Ref<SvcPhysicsCfg> _cfg )
			:
			base( _cfg )
		{
		}

		public void run()
		{
			while( true )
			{
				procMsg_block();
				//Thread.Sleep(1);
			}

			//Thread.Sleep(1000);
		}


	}


}
