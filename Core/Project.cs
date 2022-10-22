namespace GameEngineDemo2.Core;

/// <summary>
/// 프로젝트 파일 정보 클래스
/// </summary>
public static class Project
{
    public static string? Root { get; set; } = Path.GetFullPath(@"..\..\..\Sample\Scripts\");
}