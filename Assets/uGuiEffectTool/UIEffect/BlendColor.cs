/*
uGui-Effect-Tool
Copyright (c) 2015 WestHillApps (Hironari Nishioka)
This software is released under the MIT License.
http://opensource.org/licenses/mit-license.php
*/
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

namespace uGui
{
    [AddComponentMenu ("UI/Effects/Blend Color")]
    public class BlendColor : BaseVertexEffect
    {
        public enum BLEND_MODE
        {
            Multiply,
            Additive,
            Subtractive,
            Override,
        }

        public BLEND_MODE blendMode = BLEND_MODE.Multiply;
        public Color color = Color.grey;

        public override void ModifyVertices (List<UIVertex> vList)
        {
            if (IsActive () == false || vList == null || vList.Count == 0) {
                return;
            }

            UIVertex tempVertex = vList[0];
            for (int i = 0; i < vList.Count; i++) {
                tempVertex = vList[i];
                byte orgAlpha = tempVertex.color.a;
                switch (blendMode) {
                    case BLEND_MODE.Multiply:
                        tempVertex.color *= color;
                        break;
                    case BLEND_MODE.Additive:
                        tempVertex.color += color;
                        break;
                    case BLEND_MODE.Subtractive:
                        tempVertex.color -= color;
                        break;
                    case BLEND_MODE.Override:
                        tempVertex.color = color;
                        break;
                }
                tempVertex.color.a = orgAlpha;
                vList[i] = tempVertex;
            }
        }
    }
}
