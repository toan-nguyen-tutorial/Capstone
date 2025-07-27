import xml.etree.ElementTree as ET
import xml.dom.minidom as minidom

def create_value_element(value):
    val = ET.Element("Value")
    val.text = value
    return val

def generate_bacnet_valves_values_xml():
    root = ET.Element("Values")
    
    for i in range(20):
        # Comment for each valve set
        comment = ET.Comment(f" Set {i+1} ")
        root.append(comment)
        
        # Calculate starting instance for BINARY_VALUE
        bv_start = 120 + i * 6
        
        # OBJECT_BINARY_VALUE (120-125, 126-131, 132-137, ...)
        for j in range(6):
            root.append(create_value_element(f"OBJECT_BINARY_VALUE:{bv_start+j}"))
        
        # OBJECT_ANALOG_VALUE (40-42, 43-45, 46-48, ...)
        av_start = 40 + i * 3
        for j in range(3):
            root.append(create_value_element(f"OBJECT_ANALOG_VALUE:{av_start+j}"))
    
    # Convert to pretty-printed XML
    rough_string = ET.tostring(root, 'utf-8')
    reparsed = minidom.parseString(rough_string)
    pretty_xml = reparsed.toprettyxml(indent="    ")
    
    # Write to file
    with open('bacnet_valves_values.xml', 'w', encoding='utf-8') as f:
        f.write(pretty_xml)

if __name__ == "__main__":
    generate_bacnet_valves_values_xml()