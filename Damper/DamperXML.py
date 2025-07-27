import xml.etree.ElementTree as ET
import xml.dom.minidom as minidom

def create_property_element(id, tag, value):
    prop = ET.Element("Property", Id=id, Tag=tag)
    val = ET.SubElement(prop, "Value")
    val.text = str(value)
    return prop

def create_object_element(type, instance, properties, comment=None):
    if comment:
        obj = ET.Element("Object", Type=type, Instance=str(instance))
        obj.append(ET.Comment(comment))
    else:
        obj = ET.Element("Object", Type=type, Instance=str(instance))
    props = ET.SubElement(obj, "Properties")
    for prop in properties:
        if not isinstance(prop, ET.Element):
            raise TypeError(f"Property must be an Element, got {type(prop)}: {prop}")
        props.append(prop)
    return obj

def generate_bacnet_dampers_xml():
    root = ET.Element("Objects")
    
    for i in range(5):
        # Comment for each damper set
  
        
        # Common properties for BINARY_VALUE
        common_binary_properties = [
            create_property_element("PROP_DESCRIPTION", "BACNET_APPLICATION_TAG_CHARACTER_STRING", f"DAMPER{i+1}_GROUP"),
            create_property_element("PROP_EVENT_STATE", "BACNET_APPLICATION_TAG_ENUMERATED", "0"),
            create_property_element("PROP_OBJECT_TYPE", "BACNET_APPLICATION_TAG_ENUMERATED", "15"),
            create_property_element("PROP_OUT_OF_SERVICE", "BACNET_APPLICATION_TAG_BOOLEAN", "False"),
            create_property_element("PROP_RELIABILITY", "BACNET_APPLICATION_TAG_ENUMERATED", "0"),
            create_property_element("PROP_STATUS_FLAGS", "BACNET_APPLICATION_TAG_BIT_STRING", "0000"),
            create_property_element("PROP_UNITS", "BACNET_APPLICATION_TAG_ENUMERATED", "62")
        ]
        
        # Calculate starting instance for BINARY_VALUE
        bv_start = 240 + i * 6
        
        # DAMPER_Mode_BV (240, 246, 252, 258, 264)
        properties = common_binary_properties.copy()
        properties.insert(2, create_property_element("PROP_OBJECT_IDENTIFIER", "BACNET_APPLICATION_TAG_OBJECT_ID", f"OBJECT_BINARY_VALUE:{bv_start}"))
        properties.insert(3, create_property_element("PROP_OBJECT_NAME", "BACNET_APPLICATION_TAG_CHARACTER_STRING", f"DAMPER{i+1}_MODE_BV{bv_start}"))
        properties.append(create_property_element("PROP_PRESENT_VALUE", "BACNET_APPLICATION_TAG_UNSIGNED_INT", "0"))
        root.append(create_object_element("OBJECT_BINARY_VALUE", bv_start, properties))
        
        # DAMPER_Open_BV (241, 247, 253, 259, 265)
        properties = common_binary_properties.copy()
        properties.insert(2, create_property_element("PROP_OBJECT_IDENTIFIER", "BACNET_APPLICATION_TAG_OBJECT_ID", f"OBJECT_BINARY_VALUE:{bv_start+1}"))
        properties.insert(3, create_property_element("PROP_OBJECT_NAME", "BACNET_APPLICATION_TAG_CHARACTER_STRING", f"DAMPER{i+1}_OPEN_BV{bv_start+1}"))
        properties.append(create_property_element("PROP_PRESENT_VALUE", "BACNET_APPLICATION_TAG_UNSIGNED_INT", "0"))
        root.append(create_object_element("OBJECT_BINARY_VALUE", bv_start+1, properties))
        
        # DAMPER_Close_BV (242, 248, 254, 260, 266)
        properties = common_binary_properties.copy()
        properties.insert(2, create_property_element("PROP_OBJECT_IDENTIFIER", "BACNET_APPLICATION_TAG_OBJECT_ID", f"OBJECT_BINARY_VALUE:{bv_start+2}"))
        properties.insert(3, create_property_element("PROP_OBJECT_NAME", "BACNET_APPLICATION_TAG_CHARACTER_STRING", f"DAMPER{i+1}_CLOSE_BV{bv_start+2}"))
        properties.append(create_property_element("PROP_PRESENT_VALUE", "BACNET_APPLICATION_TAG_UNSIGNED_INT", "0"))
        root.append(create_object_element("OBJECT_BINARY_VALUE", bv_start+2, properties))
        
        # DAMPER_Reset_BV (243, 249, 255, 261, 267)
        properties = common_binary_properties.copy()
        properties.insert(2, create_property_element("PROP_OBJECT_IDENTIFIER", "BACNET_APPLICATION_TAG_OBJECT_ID", f"OBJECT_BINARY_VALUE:{bv_start+3}"))
        properties.insert(3, create_property_element("PROP_OBJECT_NAME", "BACNET_APPLICATION_TAG_CHARACTER_STRING", f"DAMPER{i+1}_RESET_BV{bv_start+3}"))
        properties.append(create_property_element("PROP_PRESENT_VALUE", "BACNET_APPLICATION_TAG_ENUMERATED", "0"))
        root.append(create_object_element("OBJECT_BINARY_VALUE", bv_start+3, properties))
        
        # DAMPER_OpenFeedback_BV (244, 250, 256, 262, 268)
        properties = common_binary_properties.copy()
        properties.insert(2, create_property_element("PROP_OBJECT_IDENTIFIER", "BACNET_APPLICATION_TAG_OBJECT_ID", f"OBJECT_BINARY_VALUE:{bv_start+4}"))
        properties.insert(3, create_property_element("PROP_OBJECT_NAME", "BACNET_APPLICATION_TAG_CHARACTER_STRING", f"DAMPER{i+1}_OPENFEEDBACK_BV{bv_start+4}"))
        properties.append(create_property_element("PROP_PRESENT_VALUE", "BACNET_APPLICATION_TAG_BOOLEAN", "False"))
        root.append(create_object_element("OBJECT_BINARY_VALUE", bv_start+4, properties))
        
        # DAMPER_Fault_BV (245, 251, 257, 263, 269)
        properties = common_binary_properties.copy()
        properties.insert(2, create_property_element("PROP_OBJECT_IDENTIFIER", "BACNET_APPLICATION_TAG_OBJECT_ID", f"OBJECT_BINARY_VALUE:{bv_start+5}"))
        properties.insert(3, create_property_element("PROP_OBJECT_NAME", "BACNET_APPLICATION_TAG_CHARACTER_STRING", f"DAMPER{i+1}_FAULT_BV{bv_start+5}"))
        properties.append(create_property_element("PROP_PRESENT_VALUE", "BACNET_APPLICATION_TAG_BOOLEAN", "False"))
        root.append(create_object_element("OBJECT_BINARY_VALUE", bv_start+5, properties))
        
        # ANALOG_VALUE for SetPosition
        av_start = 120 + i * 2
        analog_properties = [
            create_property_element("PROP_DESCRIPTION", "BACNET_APPLICATION_TAG_CHARACTER_STRING", f"DAMPER{i+1}_GROUP"),
            create_property_element("PROP_EVENT_STATE", "BACNET_APPLICATION_TAG_ENUMERATED", "0"),
            create_property_element("PROP_OBJECT_IDENTIFIER", "BACNET_APPLICATION_TAG_OBJECT_ID", f"OBJECT_ANALOG_VALUE:{av_start}"),
            create_property_element("PROP_OBJECT_NAME", "BACNET_APPLICATION_TAG_CHARACTER_STRING", f"SetPosition_DAMPER{i+1}_AV{av_start}"),
            create_property_element("PROP_OBJECT_TYPE", "BACNET_APPLICATION_TAG_ENUMERATED", "2"),
            create_property_element("PROP_OUT_OF_SERVICE", "BACNET_APPLICATION_TAG_BOOLEAN", "False"),
            create_property_element("PROP_PRESENT_VALUE", "BACNET_APPLICATION_TAG_REAL", "0"),
            create_property_element("PROP_RELIABILITY", "BACNET_APPLICATION_TAG_ENUMERATED", "0"),
            create_property_element("PROP_STATUS_FLAGS", "BACNET_APPLICATION_TAG_BIT_STRING", "0000"),
            create_property_element("PROP_UNITS", "BACNET_APPLICATION_TAG_ENUMERATED", "62")
        ]
        root.append(create_object_element("OBJECT_ANALOG_VALUE", av_start, analog_properties))
        
        # ANALOG_VALUE for DamperPosition
        analog_properties = analog_properties.copy()
        analog_properties[2] = create_property_element("PROP_OBJECT_IDENTIFIER", "BACNET_APPLICATION_TAG_OBJECT_ID", f"OBJECT_ANALOG_VALUE:{av_start+1}")
        analog_properties[3] = create_property_element("PROP_OBJECT_NAME", "BACNET_APPLICATION_TAG_CHARACTER_STRING", f"DamperPosition_DAMPER{i+1}_AV{av_start+1}")
        root.append(create_object_element("OBJECT_ANALOG_VALUE", av_start+1, analog_properties))
    
    # Convert to pretty-printed XML
    rough_string = ET.tostring(root, 'utf-8')
    reparsed = minidom.parseString(rough_string)
    pretty_xml = reparsed.toprettyxml(indent="    ")
    
    # Write to file
    with open('bacnet_dampers.xml', 'w', encoding='utf-8') as f:
        f.write(pretty_xml)

if __name__ == "__main__":
    generate_bacnet_dampers_xml()