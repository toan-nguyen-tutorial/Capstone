import xml.etree.ElementTree as ET
import xml.dom.minidom as minidom

def create_value_element(value):
    val = ET.Element("Value")
    val.text = value
    return val

def generate_bacnet_values_xml():
    root = ET.Element("Values")
    
    for i in range(20):
        # Comment for each motor set
        comment = ET.Comment(f" Set {i+1} ")
        root.append(comment)
        
        # Calculate starting instance for BINARY_VALUE
        bv_start = i * 6
        
        # OBJECT_BINARY_VALUE (0-5, 6-11, 12-17, ...)
        for j in range(6):
            root.append(create_value_element(f"OBJECT_BINARY_VALUE:{bv_start+j}"))
        
        # OBJECT_ANALOG_VALUE (0-1, 2-3, 4-5, ...)
        av_start = i * 2
        root.append(create_value_element(f"OBJECT_ANALOG_VALUE:{av_start}"))
        root.append(create_value_element(f"OBJECT_ANALOG_VALUE:{av_start+1}"))
        
        # OBJECT_DATETIME_VALUE (0, 1, 2, ...)
        root.append(create_value_element(f"OBJECT_DATETIME_VALUE:{i}"))
    
    # Convert to pretty-printed XML
    rough_string = ET.tostring(root, 'utf-8')
    reparsed = minidom.parseString(rough_string)
    pretty_xml = reparsed.toprettyxml(indent="    ")
    
    # Write to file
    with open('bacnet_values.xml', 'w', encoding='utf-8') as f:
        f.write(pretty_xml)

if __name__ == "__main__":
    generate_bacnet_values_xml()