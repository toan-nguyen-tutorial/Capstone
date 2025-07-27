import xml.etree.ElementTree as ET
import xml.dom.minidom as minidom

def create_property_element(id, tag, value):
    prop = ET.Element("Property", Id=id, Tag=tag)
    val = ET.SubElement(prop, "Value")
    val.text = str(value)
    return prop

def create_object_element(type, instance, properties):
    obj = ET.Element("Object", Type=type, Instance=str(instance))
    props = ET.SubElement(obj, "Properties")
    for prop in properties:
        props.append(prop)
    return obj

def generate_bacnet_xml():
    root = ET.Element("Objects")
    
    for i in range(20):
        # Common properties for BINARY_VALUE and ANALOG_VALUE
        common_properties = [
            create_property_element("PROP_DESCRIPTION", "BACNET_APPLICATION_TAG_CHARACTER_STRING", f"MOTOR{i+1}_GROUP"),
            create_property_element("PROP_EVENT_STATE", "BACNET_APPLICATION_TAG_ENUMERATED", "0"),
            create_property_element("PROP_OBJECT_IDENTIFIER", "BACNET_APPLICATION_TAG_OBJECT_ID", f"OBJECT_BINARY_VALUE:{i*6}"),
            create_property_element("PROP_OBJECT_TYPE", "BACNET_APPLICATION_TAG_ENUMERATED", "15"),
            create_property_element("PROP_OUT_OF_SERVICE", "BACNET_APPLICATION_TAG_BOOLEAN", "False"),
            create_property_element("PROP_RELIABILITY", "BACNET_APPLICATION_TAG_ENUMERATED", "0"),
            create_property_element("PROP_STATUS_FLAGS", "BACNET_APPLICATION_TAG_BIT_STRING", "0000"),
            create_property_element("PROP_UNITS", "BACNET_APPLICATION_TAG_ENUMERATED", "62")
        ]
        
        # MOTOR_Mode_BV (0, 6, 12, ...)
        properties = common_properties.copy()
        properties[2] = create_property_element("PROP_OBJECT_IDENTIFIER", "BACNET_APPLICATION_TAG_OBJECT_ID", f"OBJECT_BINARY_VALUE:{i*6}")
        properties.insert(3, create_property_element("PROP_OBJECT_NAME", "BACNET_APPLICATION_TAG_CHARACTER_STRING", f"MOTOR{i+1}_Mode_BV{i*6}"))
        properties.append(create_property_element("PROP_PRESENT_VALUE", "BACNET_APPLICATION_TAG_UNSIGNED_INT", "0"))
        root.append(create_object_element("OBJECT_BINARY_VALUE", i*6, properties))
        
        # MOTOR_Start_BV (1, 7, 13, ...)
        properties = common_properties.copy()
        properties[2] = create_property_element("PROP_OBJECT_IDENTIFIER", "BACNET_APPLICATION_TAG_OBJECT_ID", f"OBJECT_BINARY_VALUE:{i*6+1}")
        properties.insert(3, create_property_element("PROP_OBJECT_NAME", "BACNET_APPLICATION_TAG_CHARACTER_STRING", f"MOTOR{i+1}_Start_BV{i*6+1}"))
        properties.append(create_property_element("PROP_PRESENT_VALUE", "BACNET_APPLICATION_TAG_UNSIGNED_INT", "0"))
        root.append(create_object_element("OBJECT_BINARY_VALUE", i*6+1, properties))
        
        # MOTOR_Stop_BV (2, 8, 14, ...)
        properties = common_properties.copy()
        properties[2] = create_property_element("PROP_OBJECT_IDENTIFIER", "BACNET_APPLICATION_TAG_OBJECT_ID", f"OBJECT_BINARY_VALUE:{i*6+2}")
        properties.insert(3, create_property_element("PROP_OBJECT_NAME", "BACNET_APPLICATION_TAG_CHARACTER_STRING", f"MOTOR{i+1}_Stop_BV{i*6+2}"))
        properties.append(create_property_element("PROP_PRESENT_VALUE", "BACNET_APPLICATION_TAG_UNSIGNED_INT", "0"))
        root.append(create_object_element("OBJECT_BINARY_VALUE", i*6+2, properties))
        
        # MOTOR_Reset_BV (3, 9, 15, ...)
        properties = common_properties.copy()
        properties[2] = create_property_element("PROP_OBJECT_IDENTIFIER", "BACNET_APPLICATION_TAG_OBJECT_ID", f"OBJECT_BINARY_VALUE:{i*6+3}")
        properties.insert(3, create_property_element("PROP_OBJECT_NAME", "BACNET_APPLICATION_TAG_CHARACTER_STRING", f"MOTOR{i+1}_Reset_BV{i*6+3}"))
        properties.append(create_property_element("PROP_PRESENT_VALUE", "BACNET_APPLICATION_TAG_UNSIGNED_INT", "0"))
        root.append(create_object_element("OBJECT_BINARY_VALUE", i*6+3, properties))
        
        # MOTOR_RunFeedBack_BV (4, 10, 16, ...)
        properties = common_properties.copy()
        properties[2] = create_property_element("PROP_OBJECT_IDENTIFIER", "BACNET_APPLICATION_TAG_OBJECT_ID", f"OBJECT_BINARY_VALUE:{i*6+4}")
        properties.insert(3, create_property_element("PROP_OBJECT_NAME", "BACNET_APPLICATION_TAG_CHARACTER_STRING", f"MOTOR{i+1}_RunFeedBack_BV{i*6+4}"))
        properties.append(create_property_element("PROP_PRESENT_VALUE", "BACNET_APPLICATION_TAG_BOOLEAN", "False"))
        root.append(create_object_element("OBJECT_BINARY_VALUE", i*6+4, properties))
        
        # MOTOR_Fault_BV (5, 11, 17, ...)
        properties = common_properties.copy()
        properties[2] = create_property_element("PROP_OBJECT_IDENTIFIER", "BACNET_APPLICATION_TAG_OBJECT_ID", f"OBJECT_BINARY_VALUE:{i*6+5}")
        properties.insert(3, create_property_element("PROP_OBJECT_NAME", "BACNET_APPLICATION_TAG_CHARACTER_STRING", f"MOTOR{i+1}_Fault_BV{i*6+5}"))
        properties.append(create_property_element("PROP_PRESENT_VALUE", "BACNET_APPLICATION_TAG_BOOLEAN", "False"))
        root.append(create_object_element("OBJECT_BINARY_VALUE", i*6+5, properties))
        
        # ANALOG_VALUE for SPEED
        analog_properties = [
            create_property_element("PROP_DESCRIPTION", "BACNET_APPLICATION_TAG_CHARACTER_STRING", f"M{i+1}_GROUP"),
            create_property_element("PROP_EVENT_STATE", "BACNET_APPLICATION_TAG_ENUMERATED", "0"),
            create_property_element("PROP_OBJECT_IDENTIFIER", "BACNET_APPLICATION_TAG_OBJECT_ID", f"OBJECT_ANALOG_VALUE:{i*2}"),
            create_property_element("PROP_OBJECT_NAME", "BACNET_APPLICATION_TAG_CHARACTER_STRING", f"SPEED_M{i+1}_AV{i*2}"),
            create_property_element("PROP_OBJECT_TYPE", "BACNET_APPLICATION_TAG_ENUMERATED", "2"),
            create_property_element("PROP_OUT_OF_SERVICE", "BACNET_APPLICATION_TAG_BOOLEAN", "False"),
            create_property_element("PROP_PRESENT_VALUE", "BACNET_APPLICATION_TAG_REAL", "0"),
            create_property_element("PROP_RELIABILITY", "BACNET_APPLICATION_TAG_ENUMERATED", "0"),
            create_property_element("PROP_STATUS_FLAGS", "BACNET_APPLICATION_TAG_BIT_STRING", "0000"),
            create_property_element("PROP_UNITS", "BACNET_APPLICATION_TAG_ENUMERATED", "62")
        ]
        root.append(create_object_element("OBJECT_ANALOG_VALUE", i*2, analog_properties))
        
        # ANALOG_VALUE for SETSPEED
        analog_properties[2] = create_property_element("PROP_OBJECT_IDENTIFIER", "BACNET_APPLICATION_TAG_OBJECT_ID", f"OBJECT_ANALOG_VALUE:{i*2+1}")
        analog_properties[3] = create_property_element("PROP_OBJECT_NAME", "BACNET_APPLICATION_TAG_CHARACTER_STRING", f"SETSPEED_M{i+1}_AV{i*2+1}")
        root.append(create_object_element("OBJECT_ANALOG_VALUE", i*2+1, analog_properties))
        
        # DATETIME_VALUE
        datetime_properties = [
            create_property_element("PROP_OBJECT_IDENTIFIER", "BACNET_APPLICATION_TAG_OBJECT_ID", f"OBJECT_DATETIME_VALUE:{i}"),
            create_property_element("PROP_OBJECT_TYPE", "BACNET_APPLICATION_TAG_ENUMERATED", "44"),
            create_property_element("PROP_OBJECT_NAME", "BACNET_APPLICATION_TAG_CHARACTER_STRING", f"RUNTIME_M{i+1}_DTV{i}"),
            create_property_element("PROP_DESCRIPTION", "BACNET_APPLICATION_TAG_CHARACTER_STRING", "Date Time Value Object"),
            create_property_element("PROP_PRESENT_VALUE", "BACNET_APPLICATION_TAG_CHARACTER_STRING", "00:00:00"),
            create_property_element("PROP_STATUS_FLAGS", "BACNET_APPLICATION_TAG_BIT_STRING", "0000"),
            create_property_element("PROP_OUT_OF_SERVICE", "BACNET_APPLICATION_TAG_BOOLEAN", "False")
        ]
        root.append(create_object_element("OBJECT_DATETIME_VALUE", i, datetime_properties))
    
    # Convert to pretty-printed XML
    rough_string = ET.tostring(root, 'utf-8')
    reparsed = minidom.parseString(rough_string)
    pretty_xml = reparsed.toprettyxml(indent="    ")
    
    # Write to file
    with open('bacnet_20objects.xml', 'w', encoding='utf-8') as f:
        f.write(pretty_xml)

if __name__ == "__main__":
    generate_bacnet_xml()