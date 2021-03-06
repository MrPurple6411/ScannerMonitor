namespace ScannerMonitor.Components
{
    using UnityEngine;
    using UnityEngine.EventSystems;
    using UnityEngine.UI;

    /**
     * Component that will be added onto the item button.
     */
    public class ItemButton : OnScreenButton, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        public TechType type = TechType.None;
        public RawImage rawImage;
        public MapRoomFunctionality mapRoomFunctionality;

        public void Awake()
        {
            rawImage = GetComponent<RawImage>();
            rawImage.color = new Color(0.07843138f, 0.3843137f, 0.7058824f);
        }

        public TechType Type
        {
            set
            {
                HoverText = Language.main?.Get(value) ?? value.AsString();
                type = value;
            }
        }

        public override void Update()
        {
            base.Update();

            if(mapRoomFunctionality.typeToScan != TechType.None && !IsHovered)
            {
                if(mapRoomFunctionality.typeToScan == type)
                    rawImage.color = new Color(0.07843137f, 0.1459579f, 0.7058824f);
                else
                    rawImage.color = new Color(0.07843138f, 0.3843137f, 0.7058824f);
            }

        }

        public override void OnPointerClick(PointerEventData eventData)
        {
            base.OnPointerClick(eventData);
            if (IsHovered && mapRoomFunctionality != null && type != TechType.None)
            {
                if(mapRoomFunctionality.typeToScan == type)
                {
                    mapRoomFunctionality.StartScanning(TechType.None);
                    return;
                }

                mapRoomFunctionality.StartScanning(type);
            }
        }
        
        public override void OnPointerEnter(PointerEventData eventData)
        {
            base.OnPointerEnter(eventData);
            if (IsHovered)
                rawImage.color = new Color(0.07843137f, 0.1459579f, 0.7058824f);
        }

        public override void OnPointerExit(PointerEventData eventData)
        {
            base.OnPointerExit(eventData);
            if(mapRoomFunctionality.typeToScan != type)
                rawImage.color = new Color(0.07843138f, 0.3843137f, 0.7058824f);
        }
    }
}
