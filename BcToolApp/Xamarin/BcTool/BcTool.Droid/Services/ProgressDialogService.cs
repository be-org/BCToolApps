using Android.Content;
using AndroidHUD;
using BcTool.Configs;

namespace BcTool.Droid.Services
{
    /// <summary>
    /// �i���_�C�A���O�T�[�r�X�N���X
    /// </summary>
    public class ProgressDialogService
    {
        #region ���J���\�b�h

        /// <summary>
        /// �i���_�C�A���O�̕\��
        /// </summary>
        /// <param name="context">�R���e�L�X�g</param>
        /// <param name="config">�i���_�C�A���O�̐ݒ�N���X</param>
        public static void Show(Context context, ProgressConfig config)
        {
            AndHUD.Shared.Show(context, status: config.ProgressContent, maskType: MaskType.Clear);
        }

        /// <summary>
        /// �i���_�C�A���O�̔�\��
        /// </summary>
        /// <param name="context">�R���e�L�X�g</param>
        public static void Dismiss(Context context)
        {
            AndHUD.Shared.Dismiss(context);
        }

        #endregion
    }
}