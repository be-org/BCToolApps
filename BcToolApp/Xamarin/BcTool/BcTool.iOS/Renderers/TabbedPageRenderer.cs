using BcTool.iOS.Renderers;
using System;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(TabbedPage), typeof(TabbedPageRenderer))]
namespace BcTool.iOS.Renderers
{
	/// <summary>
	/// TabbedPage�p�����_���[
	/// </summary>
	public class TabbedPageRenderer : TabbedRenderer
	{
		public override void ViewWillLayoutSubviews()
		{
			base.ViewWillLayoutSubviews();

			TabBar.InvalidateIntrinsicContentSize();

			var orientation = UIApplication.SharedApplication.StatusBarOrientation;

			nfloat tabSize = 44.0f;

			if (orientation == UIInterfaceOrientation.LandscapeLeft ||
				orientation == UIInterfaceOrientation.LandscapeRight)
			{
				tabSize = 32.0f;
			}

			var tabFrame = TabBar.Frame;
			tabFrame.Height = tabSize;
			tabFrame.Y = View.Frame.Y;
			TabBar.Frame = tabFrame;

			// �����I�ɂڂ������ĕ`�悷�鏬�Z�炵��
			TabBar.Translucent = false;
			TabBar.Translucent = true;
		}
	}
}