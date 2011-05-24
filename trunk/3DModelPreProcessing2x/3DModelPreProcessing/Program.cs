/*  
            DO WHAT THE FUCK YOU WANT TO PUBLIC LICENSE
                    Version 2, December 2004

 Copyright (C) 2004 Sam Hocevar <sam@hocevar.net>

 Everyone is permitted to copy and distribute verbatim or modified
 copies of this license document, and changing it is allowed as long
 as the name is changed.

            DO WHAT THE FUCK YOU WANT TO PUBLIC LICENSE
   TERMS AND CONDITIONS FOR COPYING, DISTRIBUTION AND MODIFICATION

  0. You just DO WHAT THE FUCK YOU WANT TO.
*/
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;

using PreprocessingFramework;
using Preprocessing;
/**************************************************************************
*
*                          ModelPreProcessing
*
* Copyright (C)         Przemyslaw Szeptycki 2007     All Rights reserved
*
***************************************************************************/

/**
*   @file       Program.cs
*   @brief      Main file of the application
*   @author     Przemyslaw Szeptycki <pszeptycki@gmail.com>
*   @date       24-10-2007
*
*   @history
*   @item		24-10-2007 Przemyslaw Szeptycki     created at ECL (普查迈克)
*/
namespace ModelPreProcessing
{
    static class Program
    {
        [STAThreadAttribute]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                // register all file formats
                Cl3DModel.RegisterReader(new ClAbsModelReader());
                Cl3DModel.RegisterReader(new ClWrmlModelReader());
                Cl3DModel.RegisterReader(new ClXYZModelReader());
                Cl3DModel.RegisterReader(new ClModelModelReader());
                Cl3DModel.RegisterReader(new ClBntModelReader());
                Cl3DModel.RegisterReader(new ClRifModelReader());
                Cl3DModel.RegisterReader(new ClMfileModelReader());
                Cl3DModel.RegisterReader(new ClOFFModelReader());
                Cl3DModel.RegisterReader(new ClOBJModelReader());
                Cl3DModel.RegisterReader(new ClPlyModelReader());
                Cl3DModel.RegisterReader(new ClDATModelReader());

                DxForm MainForm = new DxForm("3D Face Models Preprocessing Tool", "2.9");

                ClInformationSender.RegisterReceiver(new ClNewAlgorithmViewer(MainForm.TreeView), ClInformationSender.eInformationType.eNewAlgorithm); // add new algorithm watcher to add algoritms on form

                // register all algorithms to Algorithm Builder
                ClMapObjectAlgorithmBuilder.RegisterNewAlgorithm(ClCalculateConformalParameterization.CrateAlgorithm, ClCalculateConformalParameterization.ALGORITHM_NAME);
                ClMapObjectAlgorithmBuilder.RegisterNewAlgorithm(ClRemoveOneVertex.CrateAlgorithm, ClRemoveOneVertex.ALGORITHM_NAME);
                ClMapObjectAlgorithmBuilder.RegisterNewAlgorithm(ClRemoveSingleConnections.CrateAlgorithm, ClRemoveSingleConnections.ALGORITHM_NAME);
                ClMapObjectAlgorithmBuilder.RegisterNewAlgorithm(ClRemoveSmallUnconnectedParts.CrateAlgorithm, ClRemoveSmallUnconnectedParts.ALGORITHM_NAME);
                ClMapObjectAlgorithmBuilder.RegisterNewAlgorithm(ClLoadPtsWithId.CrateAlgorithm, ClLoadPtsWithId.ALGORITHM_NAME);
                ClMapObjectAlgorithmBuilder.RegisterNewAlgorithm(ClNormalizeConformalMaps.CrateAlgorithm, ClNormalizeConformalMaps.ALGORITHM_NAME);
                ClMapObjectAlgorithmBuilder.RegisterNewAlgorithm(ClCalculateConformalFactor.CrateAlgorithm, ClCalculateConformalFactor.ALGORITHM_NAME);
                ClMapObjectAlgorithmBuilder.RegisterNewAlgorithm(ClConvertToUVParametrization.CrateAlgorithm, ClConvertToUVParametrization.ALGORITHM_NAME);
                ClMapObjectAlgorithmBuilder.RegisterNewAlgorithm(ClMobiusMapping.CrateAlgorithm, ClMobiusMapping.ALGORITHM_NAME);
                ClMapObjectAlgorithmBuilder.RegisterNewAlgorithm(ClRotateToPlaneCut.CrateAlgorithm, ClRotateToPlaneCut.ALGORITHM_NAME);
                ClMapObjectAlgorithmBuilder.RegisterNewAlgorithm(ClLockModel.CrateAlgorithm, ClLockModel.ALGORITHM_NAME);
                ClMapObjectAlgorithmBuilder.RegisterNewAlgorithm(ClCheckIfCurvatureHasBeenCalculated.CrateAlgorithm, ClCheckIfCurvatureHasBeenCalculated.ALGORITHM_NAME);
                ClMapObjectAlgorithmBuilder.RegisterNewAlgorithm(ClCheckPointsPrecision.CrateAlgorithm, ClCheckPointsPrecision.ALGORITHM_NAME);
                ClMapObjectAlgorithmBuilder.RegisterNewAlgorithm(ClRotatieModel.CrateAlgorithm, ClRotatieModel.ALGORITHM_NAME);
                ClMapObjectAlgorithmBuilder.RegisterNewAlgorithm(ClScaleModel.CrateAlgorithm, ClScaleModel.ALGORITHM_NAME);
                ClMapObjectAlgorithmBuilder.RegisterNewAlgorithm(ClMoveModel.CrateAlgorithm, ClMoveModel.ALGORITHM_NAME);
                ClMapObjectAlgorithmBuilder.RegisterNewAlgorithm(ClCorrectFacePose.CrateAlgorithm, ClCorrectFacePose.ALGORITHM_NAME);
                ClMapObjectAlgorithmBuilder.RegisterNewAlgorithm(ClRemoveRandomPartOfFace.CrateAlgorithm, ClRemoveRandomPartOfFace.ALGORITHM_NAME);
                ClMapObjectAlgorithmBuilder.RegisterNewAlgorithm(ClRemoveHalfOfTheFace.CrateAlgorithm, ClRemoveHalfOfTheFace.ALGORITHM_NAME);
                ClMapObjectAlgorithmBuilder.RegisterNewAlgorithm(ClRemovePathBetweenPoints.CrateAlgorithm, ClRemovePathBetweenPoints.ALGORITHM_NAME);
                ClMapObjectAlgorithmBuilder.RegisterNewAlgorithm(ClSetUnspecifiedPointTo.CrateAlgorithm, ClSetUnspecifiedPointTo.ALGORITHM_NAME);
                ClMapObjectAlgorithmBuilder.RegisterNewAlgorithm(ClRemoveAllLandmarks.CrateAlgorithm, ClRemoveAllLandmarks.ALGORITHM_NAME);
                ClMapObjectAlgorithmBuilder.RegisterNewAlgorithm(ClRemeshModel.CrateAlgorithm, ClRemeshModel.ALGORITHM_NAME);
                ClMapObjectAlgorithmBuilder.RegisterNewAlgorithm(ClRoundAllxyValuesSimplifyModel.CrateAlgorithm, ClRoundAllxyValuesSimplifyModel.ALGORITHM_NAME);
                ClMapObjectAlgorithmBuilder.RegisterNewAlgorithm(ClRoundUVvalues.CrateAlgorithm, ClRoundUVvalues.ALGORITHM_NAME);
                ClMapObjectAlgorithmBuilder.RegisterNewAlgorithm(ClCreateRegularGrid.CrateAlgorithm, ClCreateRegularGrid.ALGORITHM_NAME);
                ClMapObjectAlgorithmBuilder.RegisterNewAlgorithm(ClAddExpressionFRGC.CrateAlgorithm, ClAddExpressionFRGC.ALGORITHM_NAME);                
                ClMapObjectAlgorithmBuilder.RegisterNewAlgorithm(ClOrganizeFolders.CrateAlgorithm, ClOrganizeFolders.ALGORITHM_NAME);
                ClMapObjectAlgorithmBuilder.RegisterNewAlgorithm(ClOrganizeFoldersByExpression.CrateAlgorithm, ClOrganizeFoldersByExpression.ALGORITHM_NAME);
                ClMapObjectAlgorithmBuilder.RegisterNewAlgorithm(ClCurvatureSubstractionFromTheSamePoints.CrateAlgorithm, ClCurvatureSubstractionFromTheSamePoints.ALGORITHM_NAME);
                ClMapObjectAlgorithmBuilder.RegisterNewAlgorithm(ClLoadManualSpecificPoints.CrateAlgorithm, ClLoadManualSpecificPoints.ALGORITHM_NAME);
                ClMapObjectAlgorithmBuilder.RegisterNewAlgorithm(ClLoadAutomaticSpecificPoints.CrateAlgorithm, ClLoadAutomaticSpecificPoints.ALGORITHM_NAME);
                ClMapObjectAlgorithmBuilder.RegisterNewAlgorithm(ClLoadModelCurvaturesValues.CrateAlgorithm, ClLoadModelCurvaturesValues.ALGORITHM_NAME);
                ClMapObjectAlgorithmBuilder.RegisterNewAlgorithm(ClLoadModelTextureFRGC.CrateAlgorithm, ClLoadModelTextureFRGC.ALGORITHM_NAME);
                ClMapObjectAlgorithmBuilder.RegisterNewAlgorithm(ClLoadLandmarksBosphourus.CrateAlgorithm, ClLoadLandmarksBosphourus.ALGORITHM_NAME);
                ClMapObjectAlgorithmBuilder.RegisterNewAlgorithm(ClLoadModelTextureBosphorus.CrateAlgorithm, ClLoadModelTextureBosphorus.ALGORITHM_NAME);
                ClMapObjectAlgorithmBuilder.RegisterNewAlgorithm(ClLoadXiangManual.CrateAlgorithm, ClLoadXiangManual.ALGORITHM_NAME);
                ClMapObjectAlgorithmBuilder.RegisterNewAlgorithm(ClLoadGavabManual.CrateAlgorithm, ClLoadGavabManual.ALGORITHM_NAME);
                ClMapObjectAlgorithmBuilder.RegisterNewAlgorithm(ClSaveModel.CrateAlgorithm, ClSaveModel.ALGORITHM_NAME);
                ClMapObjectAlgorithmBuilder.RegisterNewAlgorithm(ClSaveModelToObj.CrateAlgorithm, ClSaveModelToObj.ALGORITHM_NAME);
                ClMapObjectAlgorithmBuilder.RegisterNewAlgorithm(ClSaveModelToMFile.CrateAlgorithm, ClSaveModelToMFile.ALGORITHM_NAME);
                ClMapObjectAlgorithmBuilder.RegisterNewAlgorithm(ClSaveToMFileNew.CrateAlgorithm, ClSaveToMFileNew.ALGORITHM_NAME);
                ClMapObjectAlgorithmBuilder.RegisterNewAlgorithm(ClSaveSpecificPointsCoordinates.CrateAlgorithm, ClSaveSpecificPointsCoordinates.ALGORITHM_NAME);
                ClMapObjectAlgorithmBuilder.RegisterNewAlgorithm(ClSaveManualLandmarks.CrateAlgorithm, ClSaveManualLandmarks.ALGORITHM_NAME);
                ClMapObjectAlgorithmBuilder.RegisterNewAlgorithm(ClSaveSpecificPointsWithIDs.CrateAlgorithm, ClSaveSpecificPointsWithIDs.ALGORITHM_NAME);
                ClMapObjectAlgorithmBuilder.RegisterNewAlgorithm(ClSaveModelCurvaturesValues.CrateAlgorithm, ClSaveModelCurvaturesValues.ALGORITHM_NAME);
                ClMapObjectAlgorithmBuilder.RegisterNewAlgorithm(ClSaveObjectBitmap.CrateAlgorithm, ClSaveObjectBitmap.ALGORITHM_NAME);
                ClMapObjectAlgorithmBuilder.RegisterNewAlgorithm(ClRasterizeModel.CrateAlgorithm, ClRasterizeModel.ALGORITHM_NAME);
                ClMapObjectAlgorithmBuilder.RegisterNewAlgorithm(ClSaveNoseTipXYandEyesAngle.CrateAlgorithm, ClSaveNoseTipXYandEyesAngle.ALGORITHM_NAME);
                ClMapObjectAlgorithmBuilder.RegisterNewAlgorithm(ClSaveRotationAndTranslationToGenModel.CrateAlgorithm, ClSaveRotationAndTranslationToGenModel.ALGORITHM_NAME);
                ClMapObjectAlgorithmBuilder.RegisterNewAlgorithm(ClRemoveSpikesMedianFilter.CrateAlgorithm, ClRemoveSpikesMedianFilter.ALGORITHM_NAME);
                ClMapObjectAlgorithmBuilder.RegisterNewAlgorithm(ClRemoveSpikesGaussianFilter.CrateAlgorithm, ClRemoveSpikesGaussianFilter.ALGORITHM_NAME);
                ClMapObjectAlgorithmBuilder.RegisterNewAlgorithm(ClRemoveHoles.CrateAlgorithm, ClRemoveHoles.ALGORITHM_NAME);
                ClMapObjectAlgorithmBuilder.RegisterNewAlgorithm(ClRemoveHolesRangeImage.CrateAlgorithm, ClRemoveHolesRangeImage.ALGORITHM_NAME);
                ClMapObjectAlgorithmBuilder.RegisterNewAlgorithm(ClCurvaturesAndShapeIndexComputation.CrateAlgorithm, ClCurvaturesAndShapeIndexComputation.ALGORITHM_NAME);
                ClMapObjectAlgorithmBuilder.RegisterNewAlgorithm(ClCalculateCurvednessIndex.CrateAlgorithm, ClCalculateCurvednessIndex.ALGORITHM_NAME);
                ClMapObjectAlgorithmBuilder.RegisterNewAlgorithm(ClCalculateDistanceOnUVFrom3Points.CrateAlgorithm, ClCalculateDistanceOnUVFrom3Points.ALGORITHM_NAME);
                ClMapObjectAlgorithmBuilder.RegisterNewAlgorithm(ClCalculateDistanceOnXYZFrom3Points.CrateAlgorithm, ClCalculateDistanceOnXYZFrom3Points.ALGORITHM_NAME);
                ClMapObjectAlgorithmBuilder.RegisterNewAlgorithm(ClCalculateNormalVectors.CrateAlgorithm, ClCalculateNormalVectors.ALGORITHM_NAME);
                ClMapObjectAlgorithmBuilder.RegisterNewAlgorithm(ClCalculateUVExternalApp.CrateAlgorithm, ClCalculateUVExternalApp.ALGORITHM_NAME);
                ClMapObjectAlgorithmBuilder.RegisterNewAlgorithm(ClShowHKClassification.CrateAlgorithm, ClShowHKClassification.ALGORITHM_NAME);
                ClMapObjectAlgorithmBuilder.RegisterNewAlgorithm(ClShowNoseRegions.CrateAlgorithm, ClShowNoseRegions.ALGORITHM_NAME);
                ClMapObjectAlgorithmBuilder.RegisterNewAlgorithm(ClShowEyesRegions.CrateAlgorithm, ClShowEyesRegions.ALGORITHM_NAME);
                ClMapObjectAlgorithmBuilder.RegisterNewAlgorithm(ClColorModelSpecificValue.CrateAlgorithm, ClColorModelSpecificValue.ALGORITHM_NAME);
                ClMapObjectAlgorithmBuilder.RegisterNewAlgorithm(ClColorMainPointsNeighborhood.CrateAlgorithm, ClColorMainPointsNeighborhood.ALGORITHM_NAME);
                ClMapObjectAlgorithmBuilder.RegisterNewAlgorithm(ClColorNoseTipNeighborhood.CrateAlgorithm, ClColorNoseTipNeighborhood.ALGORITHM_NAME);
                ClMapObjectAlgorithmBuilder.RegisterNewAlgorithm(ClColorGeometryImage.CrateAlgorithm, ClColorGeometryImage.ALGORITHM_NAME);
                ClMapObjectAlgorithmBuilder.RegisterNewAlgorithm(ClColorModelNormalVectors.CrateAlgorithm, ClColorModelNormalVectors.ALGORITHM_NAME);
                ClMapObjectAlgorithmBuilder.RegisterNewAlgorithm(ClFindNoseTipAndEyesHKClassification.CrateAlgorithm, ClFindNoseTipAndEyesHKClassification.ALGORITHM_NAME);
                ClMapObjectAlgorithmBuilder.RegisterNewAlgorithm(ClFindNoseTipMaxVal.CrateAlgorithm, ClFindNoseTipMaxVal.ALGORITHM_NAME);
                ClMapObjectAlgorithmBuilder.RegisterNewAlgorithm(ClAddGenericModel.CrateAlgorithm, ClAddGenericModel.ALGORITHM_NAME);
                ClMapObjectAlgorithmBuilder.RegisterNewAlgorithm(ClAdjustAntropometryPoints.CrateAlgorithm, ClAdjustAntropometryPoints.ALGORITHM_NAME);
                ClMapObjectAlgorithmBuilder.RegisterNewAlgorithm(ClCropFaceBySphere.CrateAlgorithm, ClCropFaceBySphere.ALGORITHM_NAME);
                ClMapObjectAlgorithmBuilder.RegisterNewAlgorithm(ClCropFaceByGeodesicDistance.CrateAlgorithm, ClCropFaceByGeodesicDistance.ALGORITHM_NAME);
                ClMapObjectAlgorithmBuilder.RegisterNewAlgorithm(ClCropFaceEdge.CrateAlgorithm, ClCropFaceEdge.ALGORITHM_NAME);
                ClMapObjectAlgorithmBuilder.RegisterNewAlgorithm(ClCropFaceFrequencyFromTheNoseTip.CrateAlgorithm, ClCropFaceFrequencyFromTheNoseTip.ALGORITHM_NAME);
                ClMapObjectAlgorithmBuilder.RegisterNewAlgorithm(ClFaceMouth.CrateAlgorithm, ClFaceMouth.ALGORITHM_NAME);
                ClMapObjectAlgorithmBuilder.RegisterNewAlgorithm(ClCropByPlane.CrateAlgorithm, ClCropByPlane.ALGORITHM_NAME);
                ClMapObjectAlgorithmBuilder.RegisterNewAlgorithm(ClCropFaceGeodesicDistAndClosedLips.CrateAlgorithm, ClCropFaceGeodesicDistAndClosedLips.ALGORITHM_NAME);
                ClMapObjectAlgorithmBuilder.RegisterNewAlgorithm(ClCropEyesPart.CrateAlgorithm, ClCropEyesPart.ALGORITHM_NAME);
                ClMapObjectAlgorithmBuilder.RegisterNewAlgorithm(ClCropFaceSpecificValueLessThanThreshold.CrateAlgorithm, ClCropFaceSpecificValueLessThanThreshold.ALGORITHM_NAME);

                ClMapObjectAlgorithmBuilder.RegisterNewAlgorithm(ClDoSomething.CrateAlgorithm, ClDoSomething.ALGORITHM_NAME);
                //-----------------------------------------------------

                Application.Run(MainForm);
#if RENDER_1
                ClRender.getInstance().StopRendering();
#endif
                ClFasadaPreprocessing.ResetFasade();
                
            }
            catch (Exception e)
            {
#if RENDER_1
                ClRender.getInstance().StopRendering();
#endif
                if (MessageBox.Show("Unexpected error: "+e.Message+"\nRestart the application?", "Exception", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                {
                    Application.Restart();
                }
                else
                {
                    Application.Exit();
                }
            }
            
        }
    }
}