//Temp!
float CalcDistanceTessFactor (float3 vPosWs, float minDist, float maxDist, float tess)
{
    float dist = distance (vPosWs, g_vCameraPositionWs);
    float f = clamp(1.0 - (dist - minDist) / (maxDist - minDist), 0.01, 1.0) * tess;
    return f;
}

float4 CalcTriEdgeTessFactors (float3 triVertexFactors)
{
    float4 tess;
    tess.x = 0.5 * (triVertexFactors.y + triVertexFactors.z);
    tess.y = 0.5 * (triVertexFactors.x + triVertexFactors.z);
    tess.z = 0.5 * (triVertexFactors.x + triVertexFactors.y);
    tess.w = (triVertexFactors.x + triVertexFactors.y + triVertexFactors.z) / 3.0f;
    return tess;
}

float4 DistanceBasedTess (float3 v0, float3 v1, float3 v2, float minDist, float maxDist, float tess)
{
    float3 f;
    f.x = CalcDistanceTessFactor (v0,minDist,maxDist,tess);
    f.y = CalcDistanceTessFactor (v1,minDist,maxDist,tess);
    f.z = CalcDistanceTessFactor (v2,minDist,maxDist,tess);

    return CalcTriEdgeTessFactors (f);
}
