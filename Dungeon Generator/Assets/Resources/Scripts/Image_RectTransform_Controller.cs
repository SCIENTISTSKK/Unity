using UnityEngine;
using UnityEngine.UI;

public class Image_RectTransform_Controller : MonoBehaviour
{
	private float Parent_Width;
	private float Parent_Height;

	private float Parent_Pivot_Width;
	private float Parent_Pivot_Height;

	private float Image_Pivot_Width;
	private float Image_Pivot_Height;

	private float Image_Width;
	private float Image_Height;

	private float Image_Position_x;
	private float Image_Position_y;

	private float Offset_Max_x;
	private float Offset_Max_y;

	private float Offset_Min_x;
	private float Offset_Min_y;

	private float x_Min;
	private float x_Max;

	private float y_Min;
	private float y_Max;

	private float Parent_Pivot_x;
	private float Parent_Pivot_y;

	private float Pivot_x;
	private float Pivot_y;


	void Start ()
	{
		Image Sample = this.GetComponent<Image> ();
		Transform Parent = Sample.rectTransform.parent;

		if (Parent is RectTransform) {
			RectTransform Parent_Rect = Parent.GetComponent<RectTransform> ();

			Parent_Pivot_x = Parent_Rect.pivot.x;
			Parent_Pivot_y = Parent_Rect.pivot.y;

			Parent_Width = Parent_Rect.rect.width;
			Parent_Height = Parent_Rect.rect.height;

			Parent_Pivot_Width = Parent_Width * Parent_Pivot_x;
			Parent_Pivot_Height = Parent_Height * Parent_Pivot_y;

			Pivot_x = Sample.rectTransform.pivot.x;
			Pivot_y = Sample.rectTransform.pivot.y;

			Image_Width = Sample.rectTransform.rect.width;
			Image_Height = Sample.rectTransform.rect.height;

			Image_Pivot_Width = Image_Width * Pivot_x;
			Image_Pivot_Height = Image_Height * Pivot_y;

			Image_Position_x = Sample.rectTransform.position.x - Parent_Rect.position.x;
			Image_Position_y = Sample.rectTransform.position.y - Parent_Rect.position.y;

			Offset_Min_x = Parent_Pivot_Width - Image_Pivot_Width + Image_Position_x;
			Offset_Max_x = Parent_Pivot_Width - Image_Pivot_Width + Image_Width + Image_Position_x;

			Offset_Min_y = Parent_Pivot_Height - Image_Pivot_Height + Image_Position_y;
			Offset_Max_y = Parent_Pivot_Height - Image_Pivot_Height + Image_Height + Image_Position_y;

			x_Min = Offset_Min_x / Parent_Width;
			x_Max = Offset_Max_x / Parent_Width;

			y_Min = Offset_Min_y / Parent_Height;
			y_Max = Offset_Max_y / Parent_Height;

			Sample.rectTransform.anchorMin = new Vector2 (x_Min, y_Min);
			Sample.rectTransform.anchorMax = new Vector2 (x_Max, y_Max);

			Sample.rectTransform.offsetMax = new Vector2 (0f, 0f);
			Sample.rectTransform.offsetMin = new Vector2 (0f, 0f);

		} 
	}
}
