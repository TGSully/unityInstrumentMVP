using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;

public class Controller : MonoBehaviour
{
    //[SerializeField] private ImageVisulizer _imageVisualizer;
    public ImageVisualizer ImageVisualizerPrefab;
    private List<AugmentedImage> _images = new List<AugmentedImage>();
    private ImageVisualizer activeVisualizer;
    private Dictionary<int, ImageVisualizer> m_Visualizers = new Dictionary<int, ImageVisualizer>();

    bool tracking = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Session.Status != SessionStatus.Tracking)
        {
            return;
        }

        Session.GetTrackables(_images, TrackableQueryFilter.Updated);

        foreach (var image in _images)
        {
            ImageVisualizer visualizer = null;
            m_Visualizers.TryGetValue(image.DatabaseIndex, out visualizer);
            if (image.TrackingState == TrackingState.Tracking && visualizer == null)
            {
                Anchor anchor = image.CreateAnchor(image.CenterPose);
                visualizer = (ImageVisualizer)Instantiate(ImageVisualizerPrefab, anchor.transform.position, anchor.transform.rotation);
                visualizer.Image = image;
                visualizer.transform.parent = anchor.transform;
                visualizer.transform.Rotate(90, 0, 0);
                m_Visualizers.Add(image.DatabaseIndex, visualizer);
            }
            else if (image.TrackingState == TrackingState.Stopped && visualizer != null)
            {
                m_Visualizers.Remove(image.DatabaseIndex);
                Destroy(visualizer.gameObject);

            }
        }

    }

}
